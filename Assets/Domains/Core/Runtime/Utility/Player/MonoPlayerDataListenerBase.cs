using Core.Data.Player;
using UnityEngine;

namespace Core.Utility.Player
{
    public abstract class MonoPlayerDataListenerBase : MonoBehaviour
    {
        protected PlayerData Data { get; private set; }

        #region === Unity Events ===

        protected virtual void Awake()
        {
            Data = PlayerData.Instance;
        }

        protected virtual void OnEnable()
        {
            if (Data != null) Data.DataChanged += OnPlayerDataChanged;
        }

        protected virtual void OnDisable()
        {
            if (Data != null) Data.DataChanged -= OnPlayerDataChanged;
        }
        
        #endregion === Unity Events ===
        
        protected abstract void OnPlayerDataChanged();
    }
}