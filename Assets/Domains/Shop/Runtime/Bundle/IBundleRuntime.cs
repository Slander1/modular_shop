using System;

namespace Shop.Bundle
{
    public interface IBundleRuntime
    {
        public event Action CostPlayerDataChanged;
        public void Purchase();
        public bool CanPurchase();
        public void SubscribeOnPlayerDataChange();
        public void UnsubscribeOnPlayerDataChange();
    }
}