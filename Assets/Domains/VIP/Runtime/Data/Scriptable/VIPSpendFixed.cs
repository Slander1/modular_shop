using Core.Data.Bundle.BundleBrick.Cost;
using UnityEngine;

namespace VIP.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/VIP/Spend Fixed", fileName = "VIPSpendFixed")]
    public class VIPSpendFixed : SpendFixedIntCostBrick<VIPAmount>
    { }
}