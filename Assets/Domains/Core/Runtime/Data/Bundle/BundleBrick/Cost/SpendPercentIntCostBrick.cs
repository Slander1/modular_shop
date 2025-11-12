using Core.Data.Player.Stats;
using UnityEngine;

namespace Core.Data.Bundle.BundleBrick.Cost
{
    public abstract class SpendPercentIntCostBrick<TKey> : TypedCostBrickBase<TKey, int>
        where TKey : class, ITypedPlayerStat<int>, new()
    {
        [SerializeField] [Range(0, 100)] private int percentToSpend;

        public override int Amount => percentToSpend;

        public override bool CanPurchase()
        {
            var current = CachedDataStorage.GetValue<TKey, int>();
            var cost = CalculateCost(current);
            return current >= cost && cost > 0;
        }

        public override void ExecutePurchase()
        {
            var current = CachedDataStorage.GetValue<TKey, int>();
            var cost = CalculateCost(current);
            CachedDataStorage.UpdateValue<TKey, int>(-cost);
        }

        private int CalculateCost(int currentValue)
        {
            return (currentValue * Amount) / 100;
        }
    }
}