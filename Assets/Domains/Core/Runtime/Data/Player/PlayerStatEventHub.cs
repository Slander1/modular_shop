using System;
using System.Collections.Generic;
using Core.Data.Player.Stats;

namespace Core.Data.Player
{
    public sealed class PlayerStatEventHub
    {
        private readonly Dictionary<Type, List<Delegate>> _map = new();

        public void Subscribe<TKey, T>(Action<T> listener) where TKey : class, ITypedPlayerStat<T>, new()
        {
            var key = typeof(TKey);
            
            if (!_map.TryGetValue(key, out var list))
            {
                list = new List<Delegate>();
                _map[key] = list;
            }
            
            list.Add(listener);
        }

        public void Unsubscribe<TKey, T>(Action<T> listener) where TKey : class, ITypedPlayerStat<T>, new()
        {
            var key = typeof(TKey);
            if (!_map.TryGetValue(key, out var list)) return;
            
            list.Remove(listener);
            if (list.Count == 0) _map.Remove(key);
        }

        public void Notify<TKey, T>(T value) where TKey : class, ITypedPlayerStat<T>, new()
        {
            var key = typeof(TKey);
            if (!_map.TryGetValue(key, out var list) || list.Count == 0) return;

            var snapshot = list.ToArray();
            
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < snapshot.Length; i++)
                ((Action<T>)snapshot[i])?.Invoke(value);
        }
    }
}