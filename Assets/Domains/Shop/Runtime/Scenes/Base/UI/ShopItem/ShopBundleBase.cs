using System;
using Shop.Bundle.Data;
using Shop.Scenes.Base.UI.ShopItem.Buttons;
using Shop.Scenes.ShopFront.ShopItem.Text;
using UnityEngine;

namespace Shop.Scenes.Base.UI.ShopItem
{
    public abstract class ShopBundleBase : MonoBehaviour
    {
        public event Action<BundleData> BuyButtonClicked;
        
        [SerializeField] protected BuyEventButton buyButton;
        [SerializeField] protected BundleTextHeader textPanelBase;

        protected BundleData BundleData;

        private bool _isSubscribed;
        private bool _isServerPurchaseAwait;
        
        public void Construct(BundleData bundleData)
        {
            BundleData = bundleData;
            BundleData.Construct();
            textPanelBase.UpdateText(bundleData.bundleTitile);
            
            InitializeData();
        }

        #region === Unity Events ===

        protected virtual void OnEnable()
        {
            buyButton.Clicked += BuyButtonOnClicked;
            InitializeData();
        }

        protected virtual void OnDisable()
        {
            buyButton.Clicked -= BuyButtonOnClicked;
            
            BundleData.UnsubscribeOnPlayerDataChange();
            BundleData.CostPlayerDataChanged -= BundleDataOnCostPlayerDataChanged;

            _isSubscribed = false;
        }

        #endregion

        public void OnServerPurchaseStateChange(bool isActivePurchase)
        {
            _isServerPurchaseAwait = isActivePurchase;
            
            if (isActivePurchase)
            {
                buyButton.OnServerPurchaseStateChange(true);
            }
            else
            {
                CheckPurchaseAvailability();
            }
        }
        
        private void CheckPurchaseAvailability()
        {
            if (_isServerPurchaseAwait) return;
            buyButton.SetState(BundleData.CanPurchase());
        }
        
        private void BundleDataOnCostPlayerDataChanged()
        {
            CheckPurchaseAvailability();
        }
        
        private void InitializeData()
        {
            if (_isSubscribed || BundleData == null) return;
            _isSubscribed = true;
            
            BundleData.SubscribeOnPlayerDataChange();
            BundleData.CostPlayerDataChanged += BundleDataOnCostPlayerDataChanged;
            CheckPurchaseAvailability();
        }
        
        private void BuyButtonOnClicked()
        {
            BuyButtonClicked?.Invoke(BundleData);
        }
    }
}