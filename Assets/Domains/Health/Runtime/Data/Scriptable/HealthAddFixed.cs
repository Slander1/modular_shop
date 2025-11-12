using Core.Data.Bundle.BundleBrick.Reward;
using UnityEngine;

namespace Health.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Health/Add Fixed", fileName = "HealthAddFixed")]
    public class HealthAddFixed : AddFixedIntRewardBrick<HealthAmount>
    { }
}