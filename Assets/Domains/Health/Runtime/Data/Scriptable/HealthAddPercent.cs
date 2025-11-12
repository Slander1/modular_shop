using Core.Data.Bundle.BundleBrick.Reward;
using UnityEngine;

namespace Health.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Health/Add Percent", fileName = "HealthAddPercent")]
    public class HealthAddPercent : AddPercentIntRewardBrick<HealthAmount>
    {
    }
}