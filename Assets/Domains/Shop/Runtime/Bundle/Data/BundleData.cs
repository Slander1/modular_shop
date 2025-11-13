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

namespace Shop.Bundle.Data
{
    [CreateAssetMenu(
        menuName = "Shop/Bundle Data",
        fileName = "BundleData",
        order = 0)]
    public class BundleData : ScriptableObject, ISceneLoadDataMarker
    {
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
            costBricks = BundleBricksValidator.RemoveDuplicatesByStatType(costBricks);
            rewardBricks = BundleBricksValidator.RemoveDuplicatesByStatType(rewardBricks);
            changeableBricks = BundleBricksValidator.RemoveDuplicatesByStatType(changeableBricks);
        }
        
        #endregion === Unity Events ===
        
#endif
    }
}