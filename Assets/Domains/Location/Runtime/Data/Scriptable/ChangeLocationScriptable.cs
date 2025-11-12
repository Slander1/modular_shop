using Core.Data.Bundle.BundleBrick.ChangeData;
using Core.Data.Player;
using UnityEngine;

namespace Location.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Location/Change location", fileName = "ChangeLocation")]
    public sealed class ChangeLocationScriptable : TypedDataChangeableBrick<Location, string>
    {
        public override string Value => locationName;
        
        [SerializeField] private string locationName;
        
        public override void ChangeData()
        {
            CachedDataStorage.ReplaceValue<Location, string>(Value);
        }
    }
}