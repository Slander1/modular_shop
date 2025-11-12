using Core.Data.Bundle.BundleBrick.Cost;
using Core.Data.Player;
using UnityEngine;

namespace Gold.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Gold/Spend Fixed", fileName = "GoldSpendFixed")]
    public sealed class GoldSpendFixed : SpendFixedIntCostBrick<GoldAmount>
    { }
}