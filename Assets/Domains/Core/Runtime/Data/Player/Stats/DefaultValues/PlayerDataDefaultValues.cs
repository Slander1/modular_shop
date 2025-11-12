using Core.Data.Base;
using UnityEngine;

namespace Core.Data.Player.Stats.DefaultValues
{
    [CreateAssetMenu(menuName = "Stats/Core/Default Values", fileName = "StatsDefault")]
    public class PlayerDataDefaultValues : ScriptableObject
    {
        [SerializeField] private UpdatableStatKey[] statKeys;

        public void FillPlayerDataDefaultValues(IDataStorage dataStorage)
        {
            foreach (var key in statKeys) key.UpdatePlayerData(dataStorage);
        }
    }
}