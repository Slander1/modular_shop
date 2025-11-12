using Core.Data.Player.Stats;
using UnityEngine;

namespace Core.Data.Bundle.BundleBrick.Cost
{
    public abstract class SpendFixedIntCostBrick<TKey> : TypedCostBrickBase<TKey, int>
        where TKey : class, ITypedPlayerStat<int>, new()
    {
        [SerializeField] private int amountToSpend;
        public override int Amount => amountToSpend;

        public override bool CanPurchase()
        {
            return CachedDataStorage.GetValue<TKey, int>() >= Amount;
        }

        public override void ExecutePurchase()
        {
            CachedDataStorage.UpdateValue<TKey, int>(-Amount);
        }
    }
}