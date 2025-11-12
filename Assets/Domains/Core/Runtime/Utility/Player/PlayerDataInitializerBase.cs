using Core.Data.Player;
using UnityEngine;

namespace Core.Utility.Player
{
    public abstract class PlayerDataInitializerBase : MonoBehaviour
    {
        protected IDataStorage Data;
        
        #region === Unity Events ===

        private void Awake()
        {
            Construct();
            Initialize();
        }

        #endregion === Unity Events ===

        private void Construct()
        {
            Data = PlayerData.Instance;
        }

        protected abstract void Initialize();
    }
}