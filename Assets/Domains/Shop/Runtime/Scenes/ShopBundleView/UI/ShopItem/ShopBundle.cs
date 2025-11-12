using Cysharp.Threading.Tasks;
using Shop.Bundle.Data;
using Shop.Scenes.Base;
using Shop.Scenes.Base.UI.ShopItem;

namespace Shop.Scenes.ShopBundleView.UI.ShopItem
{
    public class ShopBundle : ShopBundleBase
    {
        private readonly ServerApiAdapter _serverApi = new();
        
        protected override void BuyButtonOnClicked()
        {
            InitializePurchase(BundleData).Forget();
        }
        
        private async UniTaskVoid InitializePurchase(BundleData bundleData)
        {
            OnServerPurchaseStateChange(true);

            await _serverApi.InitializePurchase(bundleData);
            bundleData.Purchase();
            
            OnServerPurchaseStateChange(false);
        }
    }
}