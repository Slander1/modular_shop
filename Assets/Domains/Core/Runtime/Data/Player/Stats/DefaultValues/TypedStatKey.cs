using System;
using Core.Data.Base;

namespace Core.Data.Player.Stats.DefaultValues
{
    public abstract class TypedStatKey<TKey, T> : StatKey where TKey : class, ITypedPlayerStat<T>, new()
    {
        public override Type StatType => typeof(TKey);
        public abstract T Value { get; }

        public override void UpdatePlayerData(PlayerData playerData)
        {
            playerData.ReplaceValue<TKey, T>(Value);
        }
    }
}