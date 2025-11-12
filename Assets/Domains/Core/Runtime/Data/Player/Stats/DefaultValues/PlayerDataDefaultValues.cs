using UnityEngine;

namespace Core.Data.Player.Stats.DefaultValues
{
    [CreateAssetMenu(menuName = "Stats/Core/Default Values", fileName = "StatsDefault")]
    public class PlayerDataDefaultValues : ScriptableObject
    {
        [SerializeField] private StatKey[] statKeys;

        public void FillPlayerDataDefaultValues(PlayerData playerData)
        {
            foreach (var key in statKeys) key.UpdatePlayerData(playerData);
        }
    }
}