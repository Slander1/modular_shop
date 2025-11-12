using System;
using Core.Data.Player;
using Core.Data.Player.Stats;

namespace Core.Data.Bundle.BundleBrick.Cost
{
    [Serializable]
    public abstract class TypedCostBrickBase<TKey, T> : CostBrickBase where TKey : class, ITypedPlayerStat<T> , new()
    { 
        // public event Action PlayerDataChanged;
        
        public override Type StatType => typeof(TKey);
        public abstract T Amount { get; }
        
        private PlayerData _playerData;

        public override void Subscribe(PlayerData playerData)
        {
            _playerData = playerData;
            _playerData.Subscribe<TKey, T>(OnPlayerStatChanged);
        }
        
        public override void Unsubscribe()
        {
            _playerData?.Unsubscribe<TKey, T>(OnPlayerStatChanged);
            _playerData = null;
        }
        
        protected void OnPlayerStatChanged(T newValue)
        {
            CallPlayerDataChanged();
        }
    }
}