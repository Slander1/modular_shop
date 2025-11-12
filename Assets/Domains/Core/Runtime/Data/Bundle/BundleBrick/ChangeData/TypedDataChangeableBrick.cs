using System;
using Core.Data.Player.Stats;

namespace Core.Data.Bundle.BundleBrick.ChangeData
{
    public abstract class TypedDataChangeableBrick<T, TKey> : DataChangeableBrickBase where TKey : ITypedPlayerStat<T>
    {
        public override Type StatType => typeof(TKey);
        public T Value { get; }
    }
}