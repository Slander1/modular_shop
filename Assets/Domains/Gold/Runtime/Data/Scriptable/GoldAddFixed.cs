using UnityEngine;

namespace Gold.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Gold/Add Fixed", fileName = "GoldAddFixed")]
    public class GoldAddFixed : GoldAmountCostBrick
    {
        public override int Amount => goldToAdd;
        
        [SerializeField] private int goldToAdd;
    }
}