using Core.Data.Player.Stats;
using UnityEngine;

namespace Core.Data.Bundle.BundleBrick.Reward
{
    public abstract class AddPercentIntRewardBrick<TKey> : TypedRewardBrickBase<TKey, int>
        where TKey : class, ITypedPlayerStat<int>, new()
    {
        [SerializeField] [Range(0, 100)] private int percentToAdd;

        public override int Amount => percentToAdd;

        public override void GiveReward()
        {
            var current = CachedDataStorage.GetValue<TKey, int>();
            var reward = CalculateReward(current);
            CachedDataStorage.UpdateValue<TKey, int>(reward);
        }

        private int CalculateReward(int currentValue)
        {
            return (currentValue * Amount) / 100;
        }
    }
}