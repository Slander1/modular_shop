using System;
using System.Collections.Generic;
using Core.Data.Player.Stats;
using Core.Utility;

namespace Core.Data.Player
{
    //TODO : DataBase и наследоваться от него
    public sealed class PlayerData : SingletonBase<PlayerData>
    {
        //TODO : передача лямда метода и подписка каждого
        
        public event Action DataChanged
        {
            add
            {
                _dataChanged += value;
                value?.Invoke();
            }
            remove => _dataChanged -= value;
        }
        
        private readonly Dictionary<Type, IPlayerStatMarker> _dataStorage = new();
        
        private event Action _dataChanged;
        
        public T GetValue<TKey, T>() where TKey : class, ITypedPlayerStat<T>, new()
        {
            return EnsureStat<TKey, T>().CurrentValue;
        }

        public void ReplaceValue<TKey, T>(T newValue) where TKey : class, ITypedPlayerStat<T>, new()
        {
            EnsureStat<TKey, T>().ReplaceValue(newValue);
            _dataChanged?.Invoke();
        }
        
        public void UpdateValue<TKey, T>(T updateOn) where TKey : class, ITypedPlayerStat<T>, new()
        {
            EnsureStat<TKey, T>().UpdateValue(updateOn);
            _dataChanged?.Invoke();
        }

        public void ResetToDefault<TKey, T>() where TKey : class, ITypedPlayerStat<T>, new()
        {
            var stat = EnsureStat<TKey, T>();
            stat.ReplaceValue(stat.DefaultValue);
            _dataChanged?.Invoke();
        }

        public bool IsSatisfied<TKey, T>(T value) where TKey : class, ITypedPlayerStat<T>, new()
        {
            return EnsureStat<TKey, T>().IsSatisfied(value);
        }
        
        private ITypedPlayerStat<T> EnsureStat<TKey, T>() where TKey : class, ITypedPlayerStat<T>, new()
        {
            var key = typeof(TKey);
            if (_dataStorage.TryGetValue(key, out var boxed)) return (ITypedPlayerStat<T>)boxed;

            var stat = new TKey();
            _dataStorage[key] = stat;

            return stat;
        }
    }
}