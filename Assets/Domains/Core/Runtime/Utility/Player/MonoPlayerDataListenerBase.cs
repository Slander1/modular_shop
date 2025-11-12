using System;
using Core.Data.Player;
using Core.Data.Player.Stats;
using UnityEngine;

namespace Core.Utility.Player
{
    public abstract class MonoPlayerDataListenerBase<TKey, TValue> : MonoBehaviour 
        where TKey : class, ITypedPlayerStat<TValue>, new()
    {
        protected PlayerData Data { get; private set; }
        
        private Action<TValue> _cachedListener;

        #region === Unity Events ===

        protected virtual void Awake()
        {
            Data = PlayerData.Instance;
            _cachedListener = OnPlayerDataChanged;
        }

        protected virtual void OnEnable()
        {
            Data.Subscribe<TKey, TValue>(_cachedListener, invokeImmediately: true);
        }

        protected virtual void OnDisable()
        {
            Data.Unsubscribe<TKey, TValue>(_cachedListener);
        }
        
        #endregion === Unity Events ===
        
        protected abstract void OnPlayerDataChanged(TValue newValue);
    }
}