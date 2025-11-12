using System;
using Core.Data.Player.Stats;

namespace Core.Data.Bundle.BundleBrick.ChangeData
{
    public abstract class TypedDataChangeableBrick<TKey, T> : DataChangeableBrickBase where TKey : ITypedPlayerStat<T>
    {
        public override Type StatType => typeof(TKey);
        public abstract T Value { get; }
    }
}