using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Shop.Bundle.Data;
using Shop.Scenes.Base;
using Shop.Scenes.ShopFront.ShopItem;
using UnityEngine;

namespace Shop.Scenes.ShopFront.UI
{
    public sealed class ShopFrontBundlesController : MonoBehaviour
    {
        [SerializeField] private Transform bundlesContainer;
        [SerializeField] private ShopBundle shopBundle;
        
        private List<ShopBundle> _bundles;
        private ShopFrontScenesAdapter _scenesAdapter;

        private readonly ServerApiAdapter _serverApi = new();
        
        public void Construct(BundlesData bundles, ShopFrontScenesAdapter scenesAdapter)
        {
            _bundles = BundlesCreator.CreateAndInitBundles(bundlesContainer, shopBundle, bundles);
            _scenesAdapter = scenesAdapter;
            SubscribeOnBundleEvents();
        }

        #region === Unity Events ===

        private void OnDestroy()
        {
            UnsubscribeBundleEvents();
        }

        #endregion === Unity Events ===
        
        private void SubscribeOnBundleEvents()
        {
            foreach (var bundle in _bundles)
            {
                bundle.InfoButtonClicked += BundleOnInfoButtonClicked;
                bundle.BuyButtonClicked += BundleOnBuyButtonClicked;
            }
        }

        private void UnsubscribeBundleEvents()
        {
            if (_bundles == null) return;
            
            foreach (var bundle in _bundles)
            {
                bundle.InfoButtonClicked -= BundleOnInfoButtonClicked;
                bundle.BuyButtonClicked -= BundleOnBuyButtonClicked;
            }
        }
        

        private void BundleOnInfoButtonClicked(BundleData bundleData)
        {
            _scenesAdapter.OnBundleInfoClick(bundleData);
        }
        
        private void BundleOnBuyButtonClicked(BundleData bundleData, ShopBundle bundle)
        {
            InitializePurchase(bundleData, bundle).Forget();
        }

        private async UniTaskVoid InitializePurchase(BundleData bundleData, ShopBundle bundle)
        {
            bundle.OnServerPurchaseStateChange(true);

            await _serverApi.InitializePurchase(bundleData);
            try
            {
                bundleData.Purchase();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            finally
            {
                bundle.OnServerPurchaseStateChange(false);
            }
        }
    }
}