using Core.Data.Bundle.BundleBrick.Reward;
using Core.Data.Player;
using UnityEngine;

namespace Gold.Data.Scriptable
{
    [CreateAssetMenu(menuName = "Stats/Gold/Add Fixed", fileName = "GoldAddFixed")]
    public sealed class GoldAddFixed :  TypedRewardBrickBase<GoldAmount, int>
    {
        public override int Amount => goldToAdd;
        
        [SerializeField] private int goldToAdd;
        
        public override void GiveReward()
        {
            PlayerData.Instance.UpdateValue<GoldAmount, int>(Amount);
        }
    }
}