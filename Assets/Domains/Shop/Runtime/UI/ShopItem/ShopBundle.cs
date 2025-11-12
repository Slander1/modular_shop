using System;
using Shop.UI.ShopItem.Buttons;
using UnityEngine;

namespace Shop.UI.ShopItem
{
    public sealed class ShopBundle : MonoBehaviour
    {
        [SerializeField] private InfoEventButton infoButton;
        [SerializeField] private BuyEventButton buyButton;
        
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

        public void Construct()
        {
            
        }
        
        private void InfoButtonOnClicked()
        {
            throw new NotImplementedException();
        }
        
        private void BuyButtonOnClicked()
        {
            throw new NotImplementedException();
        }
    }
}