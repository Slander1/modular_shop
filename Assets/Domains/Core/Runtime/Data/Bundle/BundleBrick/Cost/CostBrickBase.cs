using Core.Data.Player;
using Unity.Plastic.Antlr3.Runtime.Misc;

namespace Core.Data.Bundle.BundleBrick.Cost
{
    public abstract class CostBrickBase : BrickBase
    {
        public event Action PlayerDataChanged;
        public abstract bool CanPurchase(PlayerData playerData);
        public abstract void Subscribe(PlayerData playerData);
        public abstract void Unsubscribe();

        protected void CallPlayerDataChanged()
        {
            PlayerDataChanged?.Invoke();
        }
    }
}