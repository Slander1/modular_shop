using System;
using Shop.Bundle.Data;
using Shop.Scenes.Base.UI.ShopItem;
using Shop.Scenes.ShopFront.ShopItem.Buttons;
using Shop.Scenes.ShopFront.ShopItem.Text;
using Shop.UI.ShopItem.Buttons;
using UnityEngine;

namespace Shop.Scenes.ShopFront.ShopItem
{
    public sealed class ShopBundle : ShopBundleBase
    {
        public event Action<BundleData> InfoButtonClicked;
        
        [SerializeField] private InfoEventButton infoButton;

        #region === Unity Events ===

        private void OnEnable()
        {
            infoButton.Clicked += InfoButtonOnClicked;
        }

        private void OnDisable()
        {
            infoButton.Clicked -= InfoButtonOnClicked;
        }

        #endregion === Unity Events ===
        
        private void InfoButtonOnClicked()
        {
            InfoButtonClicked?.Invoke(BundleData);
        }
    }
}