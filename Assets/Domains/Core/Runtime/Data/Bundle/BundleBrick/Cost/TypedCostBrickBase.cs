using System;

namespace Core.Data.Bundle.BundleBrick.Cost
{
    [Serializable]
    public abstract class TypedCostBrickBase<T> : CostBrickBase
    { 
        public T amount;
    }
}