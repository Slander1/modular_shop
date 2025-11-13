using Core.Data.Player;
using Core.Scenes;
using Shop.Bundle.Data;
using Shop.Scenes.ShopFront.UI;
using UnityEngine;

namespace Shop.Scenes.ShopFront
{
    public sealed class ShopFrontSceneInitializer : GameScene
    {
        [SerializeField] private ShopFrontBundlesController shopFrontBundlesController;
        [SerializeField] private BundlesData bundles;
        
        private ShopFrontScenesAdapter _scenesAdapter;

        #region === Unity Events ===

        private void Start()
        {
            Initialize();
        }

        #endregion === Unity Events ===

        
        public override void Construct(ISceneLoadDataMarker dataMarker)
        { }

        private void Initialize()
        {
            _scenesAdapter = new ShopFrontScenesAdapter(ScenesCoordinator.Instance);
            shopFrontBundlesController.Construct(bundles, PlayerData.Instance, _scenesAdapter);
        }
    }
}