using UnityEngine;

namespace Core.Data.Player.Stats.DefaultValues
{
    public abstract class StatKey : ScriptableObject
    {
        public abstract System.Type StatType { get; }
        public abstract void UpdatePlayerData(PlayerData playerData);
    }
}