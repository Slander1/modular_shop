using UnityEngine;

namespace Health.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Health/Default Value", fileName = "HealthStatDefault")]
    public sealed class HealthStatDefault : Core.Data.Player.Stats.DefaultValues.TypedStatKey<HealthAmount, int>
    {
        public override int Value => defaultHealth; 
        [SerializeField] private int defaultHealth;
    }
}