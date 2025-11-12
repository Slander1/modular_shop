using System;
using Shop.Bundle.Data;
using Shop.Scenes.Base.UI.ShopItem.Buttons;
using Shop.Scenes.ShopFront.ShopItem.Text;
using UnityEngine;

namespace Shop.Scenes.Base.UI.ShopItem
{
    public abstract class ShopBundleBase : MonoBehaviour
    {
        // public event Action BuyButtonClicked
        // {
        //     add => buyButton.Clicked += value;
        //     remove => buyButton.Clicked -= value;
        // }
        
        [SerializeField] protected BuyEventButton buyButton;
        [SerializeField] protected BundleTextHeader textPanelBase;

        protected BundleData BundleData;

        private bool _isSubscribed;
        
        public void Construct(BundleData bundleData)
        {
            BundleData = bundleData;
            textPanelBase.UpdateText(bundleData.bundleTitile);
            
            InitializeData();
        }

        #region === Unity Events ===

        protected virtual void OnEnable()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            if (_isSubscribed || BundleData == null) return;
            _isSubscribed = true;
            
            BundleData.SubscribeOnPlayerDataChange();
            BundleData.CostPlayerDataChanged += BundleDataOnCostPlayerDataChanged;
            CheckPurchaseAvailability();
        }

        protected virtual void OnDisable()
        {
            BundleData.UnsubscribeOnPlayerDataChange();
            BundleData.CostPlayerDataChanged -= BundleDataOnCostPlayerDataChanged;

            _isSubscribed = false;
        }

        #endregion

        private void CheckPurchaseAvailability()
        {
            buyButton.SetState(BundleData.CanPurchase());
        }
        
        private void BundleDataOnCostPlayerDataChanged()
        {
            CheckPurchaseAvailability();
        }
    }
}