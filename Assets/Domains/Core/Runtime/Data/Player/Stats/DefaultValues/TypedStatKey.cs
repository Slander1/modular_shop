using System;

namespace Core.Data.Player.Stats.DefaultValues
{
    public abstract class TypedStatKey<TKey, T> : UpdatableStatKey where TKey : class, ITypedPlayerStat<T>, new()
    {
        public override Type StatType => typeof(TKey);
        public abstract T Value { get; }

        public override void UpdatePlayerData()
        {
            PlayerData.Instance.ReplaceValue<TKey, T>(Value);
        }
    }
}