using Core.Data.Bundle.BundleBrick.Cost;
using UnityEngine;

namespace Health.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Health/Spend Fixed", fileName = "HealthSpendFixed")]
    public sealed class HealthSpendFixed : SpendFixedIntCostBrick<HealthAmount>
    {
        public override bool CanPurchase()
        {
            return CachedDataStorage.GetValue<HealthAmount, int>() > Amount;
        }
    }
}