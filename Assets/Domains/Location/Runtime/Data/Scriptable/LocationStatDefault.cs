using Core.Data.Player;
using UnityEngine;

namespace Location.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Location/Default Value", fileName = "LocationStatDefault")]

    public sealed class LocationStatDefault : Core.Data.Player.Stats.DefaultValues.TypedStatKey<Location, string>
    {
        public override string Value => defaultLocation;
        [SerializeField] private string defaultLocation;
        
        public override void UpdatePlayerData(IDataStorage dataStorage)
        {
            dataStorage.ReplaceValue<Location, string>(Value);
        }
    }
}