using System;
using Shop.Bundle.Data;
using Shop.Scenes.Base.UI.ShopItem;
using Shop.Scenes.ShopFront.ShopItem.Buttons;
using UnityEngine;

namespace Shop.Scenes.ShopFront.ShopItem
{
    public sealed class ShopBundle : ShopBundleBase
    {
        public event Action<BundleData, ShopBundle> BuyButtonClicked;
        public event Action<BundleData> InfoButtonClicked;
        
        [SerializeField] private InfoEventButton infoButton;

        #region === Unity Events ===

        protected override void OnEnable()
        {
            base.OnEnable();
            infoButton.Clicked += InfoButtonOnClicked;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            infoButton.Clicked -= InfoButtonOnClicked;
        }

        #endregion === Unity Events ===
        
        private void InfoButtonOnClicked()
        {
            if (IsServerPurchaseAwait) return;
            InfoButtonClicked?.Invoke(BundleData);
        }
        
        protected override void BuyButtonOnClicked()
        {
            if (IsServerPurchaseAwait) return;
            BuyButtonClicked?.Invoke(BundleData, this);
        }
    }
}