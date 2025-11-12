using Core.Data.Bundle.BundleBrick.Cost;
using Core.Data.Player;
using UnityEngine;

namespace Gold.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Gold/Spend Fixed", fileName = "GoldSpendFixed")]
    public sealed class GoldSpendFixed: TypedCostBrickBase<GoldAmount, int>
    {
        public override int Amount => goldToSpend;

        [SerializeField] private int goldToSpend;
        
        public override bool CanPurchase(PlayerData playerData)
        {
            var value = playerData.GetValue<GoldAmount, int>();
            return value >= Amount;
        }
    }
}