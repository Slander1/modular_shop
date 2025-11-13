using System;
using Cysharp.Threading.Tasks;
using Shop.Bundle.Data;
using Shop.Scenes.Base;
using Shop.Scenes.Base.UI.ShopItem;
using UnityEngine;

namespace Shop.Scenes.ShopBundleView.UI.ShopItem
{
    public class ShopBundle : ShopBundleBase
    {
        private readonly ServerApiAdapter _serverApi = new();
        
        protected override void BuyButtonOnClicked()
        {
            InitializePurchase().Forget();
        }
        
        private async UniTaskVoid InitializePurchase()
        {
            OnServerPurchaseStateChange(true);

            await _serverApi.InitializePurchase(BundleRuntime);
            try
            {
                BundleRuntime.Purchase();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            finally
            {
                OnServerPurchaseStateChange(false);
            }
        }
    }
}