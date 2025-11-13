using System;
using Core.Data.Player;
using Core.Scenes;
using Shop.Bundle.Data;
using Shop.Scenes.ShopBundleView.UI.ShopItem;
using Shop.Scenes.ShopBundleView.UI.UpPanel;
using UnityEngine;

namespace Shop.Scenes.ShopBundleView
{
    public class ShopBundleViewSceneInitializer : GameScene
    {
        [SerializeField] private UpPanelController upPanelController;
        [SerializeField] private ShopBundle shopBundle;
        
        private ShopBundleViewScenesAdapter _scenesAdapter;
        
        #region === Unity Events ===
        
        private void Start()
        {
            Initialize();
        }
        
        #endregion === Unity Events ===
        
        public override void Construct(ISceneLoadDataMarker dataMarker)
        {
            if (dataMarker is not BundleData bundleData)
                throw new ArgumentException("Data marker type is not BundleData");
            var dataStorage = PlayerData.Instance;
            shopBundle.Construct(bundleData, dataStorage);
        }
        
        private void Initialize()
        {
            _scenesAdapter = new ShopBundleViewScenesAdapter(ScenesCoordinator.Instance);
            upPanelController.Construct(_scenesAdapter);
        }
    }
}