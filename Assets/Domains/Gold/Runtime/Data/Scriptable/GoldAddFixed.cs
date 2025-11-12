using Core.Data.Bundle.BundleBrick.Reward;
using Core.Data.Player;
using UnityEngine;

namespace Gold.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Gold/Add Fixed", fileName = "GoldAddFixed")]
    public sealed class GoldAddFixed : AddFixedIntRewardBrick<GoldAmount>
    { }
}