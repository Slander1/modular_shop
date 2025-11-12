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

        #region === Unity Events ===

        private void Start()
        {
            Initialize();
        }

        #endregion === Unity Events ===

        
        public override void Construct(ISceneLoadData data)
        { }

        private void Initialize()
        {
            shopFrontBundlesController.Construct(bundles);
        }
    }
}