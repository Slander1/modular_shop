using System;
using Shop.Bundle.Data;
using Shop.Scenes.ShopFront.ShopItem.Text;
using Shop.UI.ShopItem.Buttons;
using UnityEngine;

namespace Shop.Scenes.Base.UI.ShopItem
{
    public abstract class ShopBundleBase : MonoBehaviour
    {
        public event Action BuyButtonClicked
        {
            add => buyButton.Clicked += value;
            remove => buyButton.Clicked -= value;
        }
        
        [SerializeField] protected BuyEventButton buyButton;
        [SerializeField] protected BundleTextHeader textPanelBase;

        protected BundleData BundleData;
        
        public void Construct(BundleData bundleData)
        {
            BundleData = bundleData;
            textPanelBase.UpdateText(bundleData.bundleTitile);
        }
    }
}