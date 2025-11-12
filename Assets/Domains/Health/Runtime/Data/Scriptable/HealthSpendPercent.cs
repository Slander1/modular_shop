using Core.Data.Bundle.BundleBrick.Cost;
using UnityEngine;

namespace Health.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Health/Spend Percent", fileName = "HealthSpendPercent")]
    public class HealthSpendPercent : SpendPercentIntCostBrick<HealthAmount>
    {
    }
}