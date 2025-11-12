using Core.Data.Player;
using Unity.Plastic.Antlr3.Runtime.Misc;

namespace Core.Data.Bundle.BundleBrick.Cost
{
    public abstract class CostBrickBase : BrickBase
    {
        public event Action PlayerDataChanged;
        
        protected IDataStorage CashedDataStorage;

        public void Construct(IDataStorage storage)
        {
            CashedDataStorage = storage;
        }
        
        public abstract bool CanPurchase();
        public abstract void Subscribe();
        public abstract void Unsubscribe();
        public abstract void ExecutePurchase();

        protected void CallPlayerDataChanged()
        {
            PlayerDataChanged?.Invoke();
        }
    }
}