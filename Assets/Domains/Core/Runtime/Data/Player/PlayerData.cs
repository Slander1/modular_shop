using System;
using System.Collections.Generic;
using Core.Data.Base;
using Core.Data.Player.Stats;
using Core.Utility;

namespace Core.Data.Player
{
    // TODO: DataBase и наследоваться от него при необходимости
    public sealed class PlayerData : SingletonBase<PlayerData>
    {
        private readonly PlayerStatEventHub _eventHub = new();

        private readonly Dictionary<Type, IGameStatMarker> _dataStorage = new();

        public T GetValue<TKey, T>() where TKey : class, ITypedPlayerStat<T>, new()
        {
            return EnsureStat<TKey, T>().Value;
        }

        public bool TryGetValue<TKey, T>(out T value)
            where TKey : class, ITypedPlayerStat<T>, new()
        {
            if (_dataStorage.TryGetValue(typeof(TKey), out var boxed))
            {
                value = ((ITypedPlayerStat<T>)boxed).Value;
                return true;
            }
            value = default!;
            return false;
        }

        public void ReplaceValue<TKey, T>(T newValue)
            where TKey : class, ITypedPlayerStat<T>, new()
        {
            var stat = EnsureStat<TKey, T>();
            stat.ReplaceValue(newValue);
            _eventHub.Notify<TKey, T>(stat.Value);
        }
        
        public void UpdateValue<TKey, T>(T updateOn)
            where TKey : class, ITypedPlayerStat<T>, new()
        {
            var stat = EnsureStat<TKey, T>();
            stat.UpdateValue(updateOn);
            _eventHub.Notify<TKey, T>(stat.Value);
        }

        public void Subscribe<TKey, T>(Action<T> listener, bool invokeImmediately = true) where TKey : class, ITypedPlayerStat<T>, new()
        {
            _eventHub.Subscribe<TKey, T>(listener);
            if (invokeImmediately)
                listener?.Invoke(GetValue<TKey, T>());
        }

        public void Unsubscribe<TKey, T>(Action<T> listener) where TKey : class, ITypedPlayerStat<T>, new()
        {
            _eventHub.Unsubscribe<TKey, T>(listener);
        }

        private ITypedPlayerStat<T> EnsureStat<TKey, T>()
            where TKey : class, ITypedPlayerStat<T>, new()
        {
            var key = typeof(TKey);
            if (_dataStorage.TryGetValue(key, out var boxed))
                return (ITypedPlayerStat<T>)boxed;

            var stat = new TKey();
            _dataStorage[key] = stat;
            return stat;
        }
    }
}