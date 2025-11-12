using UnityEngine;

namespace Gold.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Gold/Default Value", fileName = "GoldStatDefault")]
    public class GoldStatDefault : Core.Data.Player.Stats.DefaultValues.TypedStatKey<GoldAmount, int>
    {
        public override int Value => defaultGold;
        
        [SerializeField] private int defaultGold;
    }
    
    
}