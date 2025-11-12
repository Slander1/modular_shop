using System;
using Core.Utility.UI;
using Shop.Bundle.Data;
using Shop.Scenes.ShopFront.ShopItem.Text;
using Shop.UI.ShopItem.Buttons;
using UnityEngine;

namespace Shop.Scenes.ShopFront.ShopItem
{
    public sealed class ShopBundle : MonoBehaviour
    {
        public event Action InfoButtonClicked
        {
            add => infoButton.Clicked += value;
            remove => infoButton.Clicked -= value;
        }
        
        public event Action BuyButtonClicked
        {
            add => buyButton.Clicked += value;
            remove => buyButton.Clicked -= value;
        }
        
        [SerializeField] private InfoEventButton infoButton;
        [SerializeField] private BuyEventButton buyButton;
        [SerializeField] private BundleTextHeader textPanelBase;
        
        private BundleData _bundleData;
        
        #region === Unity Events ===

        private void OnEnable()
        {
            infoButton.Clicked += InfoButtonOnClicked;
            buyButton.Clicked += BuyButtonOnClicked;
        }

        private void OnDisable()
        {
            infoButton.Clicked -= InfoButtonOnClicked;
            buyButton.Clicked -= BuyButtonOnClicked;
        }

        #endregion === Unity Events ===

        public void Construct(BundleData bundleData)
        {
            _bundleData = bundleData;
            textPanelBase.UpdateText(bundleData.bundleTitile);
        }
        
        private void InfoButtonOnClicked()
        {
            
        }
        
        private void BuyButtonOnClicked()
        {
            
        }
    }
}