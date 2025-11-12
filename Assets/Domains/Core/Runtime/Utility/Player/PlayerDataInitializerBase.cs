using Core.Data.Player;
using UnityEngine;

namespace Core.Utility.Player
{
    public abstract class PlayerDataInitializerBase : MonoBehaviour
    {
        protected PlayerData PlayerData;
        
        #region === Unity Events ===

        private void Awake()
        {
            PlayerData = PlayerData.Instance;
            Initialize();
        }

        #endregion === Unity Events ===

        protected abstract void Initialize();
    }
}