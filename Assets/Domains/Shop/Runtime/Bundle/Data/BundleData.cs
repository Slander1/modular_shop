using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data.Bundle.BundleBrick;
using Core.Data.Bundle.BundleBrick.ChangeData;
using Core.Data.Bundle.BundleBrick.Cost;
using Core.Data.Bundle.BundleBrick.Reward;
using Core.Data.Player;
using Core.Scenes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Shop.Bundle.Data
{
    [CreateAssetMenu(
        menuName = "Shop/Bundle Data",
        fileName = "BundleData",
        order = 0)]
    public class BundleData : ScriptableObject, ISceneLoadDataMarker
    {
        public event Action CostPlayerDataChanged;
        
        [Header("UI")]
        [SerializeField] public string bundleTitle;
        
        [Space(10)]
        [Header("Cost — что игрок ТРАТИТ при покупке")]
        [SerializeField] public CostBrickBase[] costBricks;
        
        [Space(10)]
        [Header("Reward — что игрок ПОЛУЧАЕТ после покупки")]
        [SerializeField] public RewardBrickBase[] rewardBricks;

        [Space(10)]
        [Header("Changable Data — что меняется после покупки")]
        [SerializeField]  public DataChangeableBrickBase[] changeableBricks;


#if UNITY_EDITOR

        #region === Unity Events ===
        
        private void OnValidate()
        {
            costBricks = RemoveDuplicatesByStatType(costBricks);
            rewardBricks = RemoveDuplicatesByStatType(rewardBricks);
            changeableBricks = RemoveDuplicatesByStatType(changeableBricks);
        }
        
        #endregion === Unity Events ===
        
        
        private T[] RemoveDuplicatesByStatType<T>(T[] bricks) where T : BrickBase
        {
            if (bricks == null)
                return null;

            var seen = new HashSet<Type>();
            var result = new List<T>();

            foreach (var brick in bricks)
            {
                if (brick == null)
                {
                    result.Add(null);
                    continue;
                }

                var statType = brick.StatType;
                if (seen.Add(statType))
                {
                    result.Add(brick);
                }
                else
                {
                    result.Add(null);
                    Debug.LogWarning($"Stat type {statType} is already used by another brick");
                }
            }

            return result.ToArray();
        }
#endif

        public void Construct()
        {
            var dataStorage = PlayerData.Instance;
            
            foreach (var brick in costBricks)
            {
                brick.Construct(dataStorage);
            }
            
            foreach (var rewardBrickBase in rewardBricks)
            {
                rewardBrickBase.Construct(dataStorage);
            }
            
            foreach (var changeableBrick in changeableBricks)
            {
                changeableBrick.Construct(dataStorage);
            }
        }
        
        public bool CanPurchase()
        {
            return costBricks.All(brick => brick.CanPurchase());
        }

        public void Purchase()
        {
            if (!CanPurchase()) throw new ArgumentException("dont enough resources");
            
            foreach (var costBrickBase in costBricks)
            {
                costBrickBase.ExecutePurchase();
            }
            
            foreach (var rewardBrick in rewardBricks)
            {
                rewardBrick.GiveReward();
            }
            
            foreach (var changeableBrickBase in changeableBricks)
            {
                changeableBrickBase.ChangeData();
            }
        }
            
        public void SubscribeOnPlayerDataChange()
        {
            foreach (var brick in costBricks)
            {
                brick.Subscribe();
                brick.PlayerDataChanged += CostBrickOnPlayerDataChanged;
            }
        }

        public void UnsubscribeOnPlayerDataChange()
        {
            foreach (var brick in costBricks)
            {
                brick.Unsubscribe();
                brick.PlayerDataChanged -= CostBrickOnPlayerDataChanged;
            }
        }
        
        private void CostBrickOnPlayerDataChanged()
        {
            CostPlayerDataChanged?.Invoke();
        }
    }
}