using Core.Scenes;
using Core.Scenes.Data;
using Cysharp.Threading.Tasks;
using Shop.Bundle.Data;

namespace Shop.Scenes.ShopFront
{
    public sealed class ShopFrontScenesAdapter : ScenesAdapter
    {
        private const string BundleInfoSceneName = "Shop Bundle View Scene";
        private readonly SceneReference _bundleInfoScene;

        public ShopFrontScenesAdapter(ScenesCoordinator scenesCoordinator) : base(scenesCoordinator)
        { }

        public void OnBundleInfoClick(BundleData bundleData = null)
        {
            var navReq = new NavigationRequest(typeof(Shop.Scenes.Data.ScenesCatalog), BundleInfoSceneName, bundleData);
            ScenesCoordinator.NavigateAsync(navReq).Forget();
        }
    }
}