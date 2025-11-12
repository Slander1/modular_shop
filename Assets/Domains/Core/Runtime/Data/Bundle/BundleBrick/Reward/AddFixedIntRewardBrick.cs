using Core.Data.Player.Stats;
using UnityEngine;

namespace Core.Data.Bundle.BundleBrick.Reward
{
    public abstract class AddFixedIntRewardBrick<TKey> : TypedRewardBrickBase<TKey, int>
        where TKey : class, ITypedPlayerStat<int>, new()
    {
        [SerializeField] private int amountToAdd;

        public override int Amount => amountToAdd;

        public override void GiveReward()
        {
            CachedDataStorage.UpdateValue<TKey, int>(Amount);
        }
    }
}