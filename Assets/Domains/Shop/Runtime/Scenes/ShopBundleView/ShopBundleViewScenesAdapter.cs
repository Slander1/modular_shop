using Core.Scenes;
using Core.Scenes.Data;
using Cysharp.Threading.Tasks;

namespace Shop.Scenes.ShopBundleView
{
    public class ShopBundleViewScenesAdapter : ScenesAdapter
    {
        private const string ShopFrontSceneName = "Shop Scene";
        private readonly SceneReference _bundleInfoScene;

        public ShopBundleViewScenesAdapter(ScenesCoordinator scenesCoordinator) : base(scenesCoordinator)
        { }
        
        public void OnBackClick()
        {
            var navReq = new NavigationRequest(typeof(Shop.Scenes.Data.ScenesCatalog), ShopFrontSceneName);
            ScenesCoordinator.NavigateAsync(navReq).Forget();
        }
    }
}