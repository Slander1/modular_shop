using System;
using System.Collections.Generic;
using Core.Data.Player.Stats;
using Core.Utility;

namespace Core.Data.Player
{
    public sealed class PlayerData : SingletonBase<PlayerData>
    {
        public event Action DataChanged;

        private readonly Dictionary<Type, object> _dataStorage = new();

        public T GetValue<TKey, T>() where TKey : class, IPlayerStat<T>, new()
        {
            return EnsureStat<TKey, T>().CurrentValue;
        }

        public void ReplaceValue<TKey, T>(T newValue) where TKey : class, IPlayerStat<T>, new()
        {
            EnsureStat<TKey, T>().ReplaceValue(newValue);
            DataChanged?.Invoke();
        }
        
        public void UpdateValue<TKey, T>(T updateOn) where TKey : class, IPlayerStat<T>, new()
        {
            EnsureStat<TKey, T>().UpdateValue(updateOn);
            DataChanged?.Invoke();
        }

        public void ResetToDefault<TKey, T>() where TKey : class, IPlayerStat<T>, new()
        {
            var stat = EnsureStat<TKey, T>();
            stat.ReplaceValue(stat.DefaultValue);
            DataChanged?.Invoke();
        }
        
        private IPlayerStat<T> EnsureStat<TKey, T>() where TKey : class, IPlayerStat<T>, new()
        {
            var key = typeof(TKey);
            if (_dataStorage.TryGetValue(key, out var boxed)) return (IPlayerStat<T>)boxed;

            var stat = new TKey();
            _dataStorage[key] = stat;

            return stat;
        }
    }
}