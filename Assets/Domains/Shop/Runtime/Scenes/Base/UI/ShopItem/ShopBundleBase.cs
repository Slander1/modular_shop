    using Core.Data.Player;
    using Shop.Bundle;
    using Shop.Bundle.Data;
    using Shop.Scenes.Base.UI.ShopItem.Buttons;
    using Shop.Scenes.ShopFront.ShopItem.Text;
    using UnityEngine;

    namespace Shop.Scenes.Base.UI.ShopItem
    {
        public abstract class ShopBundleBase : MonoBehaviour
        {
            [SerializeField] protected BuyEventButton buyButton;
            [SerializeField] protected BundleTextHeader textPanelBase;

            protected BundleData BundleData;
            protected bool IsServerPurchaseAwait;
            protected IBundleRuntime BundleRuntime;
            
            private bool _isSubscribed;
            private IDataStorage _dataStorage;
            
            public void Construct(BundleData bundleData, IDataStorage dataStorage)
            {
                BundleData = bundleData;
                _dataStorage = dataStorage;
                
                BundleRuntime = new BundleRuntime(bundleData, dataStorage);
                textPanelBase.UpdateText(bundleData.bundleTitle);
                
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
                
                BundleRuntime.UnsubscribeOnPlayerDataChange();
                BundleRuntime.CostPlayerDataChanged -= BundleDataOnCostPlayerDataChanged;

                _isSubscribed = false;
            }

            #endregion

            public void OnServerPurchaseStateChange(bool isActivePurchase)
            {
                IsServerPurchaseAwait = isActivePurchase;
                
                if (isActivePurchase)
                {
                    buyButton.OnServerPurchaseStateChange(true);
                }
                else
                {
                    CheckPurchaseAvailability();
                }
            }
            
            protected abstract void BuyButtonOnClicked();
            
            private void CheckPurchaseAvailability()
            {
                if (IsServerPurchaseAwait) return;
                buyButton.SetState(BundleRuntime.CanPurchase());
            }
            
            private void BundleDataOnCostPlayerDataChanged()
            {
                CheckPurchaseAvailability();
            }
            
            private void InitializeData()
            {
                if (_isSubscribed || BundleData == null) return;
                _isSubscribed = true;
                
                BundleRuntime.SubscribeOnPlayerDataChange();
                
                BundleRuntime.CostPlayerDataChanged += BundleDataOnCostPlayerDataChanged;
                CheckPurchaseAvailability();
            }
        }
    }