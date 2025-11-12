using System;
using Core.Data.Player.Stats;

namespace Core.Data.Bundle.BundleBrick.Reward
{
    public abstract class TypedRewardBrickBase<T, TKey> : RewardBrickBase where TKey : ITypedPlayerStat<T>
    {
        public override Type StatType => typeof(TKey);
        public T amount;
    }
}