using Core.Data.Bundle.BundleBrick.Cost;
using Core.Data.Player;
using UnityEngine;

namespace Gold.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Gold/Spend Fixed", fileName = "GoldSpendFixed")]
    public sealed class GoldSpendFixed : TypedCostBrickBase<GoldAmount, int>
    {
        public override int Amount => goldToSpend;
        
        [SerializeField] private int goldToSpend;
        
        public override bool CanPurchase()
        {
            var value = PlayerData.Instance.GetValue<GoldAmount, int>();
            return value >= Amount;
        }

        public override void ExecutePurchase()
        {
            PlayerData.Instance.UpdateValue<GoldAmount, int>(-1 * Amount);
        }
    }
}