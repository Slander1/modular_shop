using Core.Data.Bundle.BundleBrick.Cost;
using UnityEngine;

namespace Gold.Data
{
    [CreateAssetMenu(menuName = "Gold/Cost/Spend Fixed", fileName = "GoldSpendFixed")]
    public sealed class GoldSpendFixed: TypedCostBrickBase<int,GoldAmount>
    {
        public override bool CanPurchase(int playerDataValue)
        {
            return playerDataValue >= amount;
        }
    }
}