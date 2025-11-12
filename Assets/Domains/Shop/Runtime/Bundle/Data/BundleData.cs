using System;
using System.Linq;
using Core.Data.Bundle.BundleBrick.ChangeData;
using Core.Data.Bundle.BundleBrick.Cost;
using Core.Data.Bundle.BundleBrick.Reward;
using Core.Data.Player;
using Core.Scenes;
using UnityEngine;

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
        [SerializeField] public string bundleTitile;
        
        [Space(10)]
        [Header("Cost — что игрок ТРАТИТ при покупке")]
        [SerializeField] public CostBrickBase[] costBricks;
        
        [Space(10)]
        [Header("Reward — что игрок ПОЛУЧАЕТ после покупки")]
        [SerializeField] public RewardBrickBase[] rewardBricks;

        [Space(10)]
        [Header("Changable Data — что меняется после покупки")]
        [SerializeField]  public DataChangeableBrickBase[] changeableBricks;

        public void Construct()
        {
            var dataStorage = PlayerData.Instance;
            
            foreach (var brick in costBricks)
            {
                brick.Construct(dataStorage);
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