using System;
using Core.Data.Player.Stats;

namespace Core.Data.Bundle.BundleBrick.Cost
{
    [Serializable]
    public abstract class TypedCostBrickBase<T, TKey> : CostBrickBase where TKey : ITypedPlayerStat<T>
    { 
        public T amount;
        public override Type StatType => typeof(TKey);
    }
}