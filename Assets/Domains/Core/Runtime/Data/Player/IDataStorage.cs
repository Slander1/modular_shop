using System;
using Core.Data.Player.Stats;

namespace Core.Data.Player
{
    public interface IDataStorage
    {
        public T GetValue<TKey, T>() where TKey : class, ITypedPlayerStat<T>, new();
        public void ReplaceValue<TKey, T>(T newValue) where TKey : class, ITypedPlayerStat<T>, new();
        public void UpdateValue<TKey, T>(T updateOn) where TKey : class, ITypedPlayerStat<T>, new();
        public void Subscribe<TKey, T>(Action<T> listener, bool invokeImmediately = true) where TKey : class, ITypedPlayerStat<T>, new();
        public void Unsubscribe<TKey, T>(Action<T> listener) where TKey : class, ITypedPlayerStat<T>, new();
    }
}