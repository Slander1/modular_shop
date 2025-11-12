using Core.Data.Bundle.BundleBrick.ChangeData;
using Core.Data.Bundle.BundleBrick.Cost;
using Core.Data.Bundle.BundleBrick.Reward;
using UnityEngine;

namespace Shop.Bundle.Data
{
    [CreateAssetMenu(
        menuName = "Shop/Bundle Data",
        fileName = "BundleData",
        order = 0)]
    public class BundleData : ScriptableObject
    {
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
    }
}