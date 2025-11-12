using System;
using Core.Data.Player;
using Core.Data.Player.Stats;

namespace Core.Data.Bundle.BundleBrick.Cost
{
    [Serializable]
    public abstract class TypedCostBrickBase<TKey, T> : CostBrickBase where TKey : class, ITypedPlayerStat<T> , new()
    { 
        public override Type StatType => typeof(TKey);
        public abstract T Amount { get; }
        
        public override void Subscribe()
        {
            CachedDataStorage.Subscribe<TKey, T>(OnPlayerStatChanged);
        }
        
        public override void Unsubscribe()
        {
            CachedDataStorage.Unsubscribe<TKey, T>(OnPlayerStatChanged);
        }
        
        protected void OnPlayerStatChanged(T newValue)
        {
            CallPlayerDataChanged();
        }
    }
}