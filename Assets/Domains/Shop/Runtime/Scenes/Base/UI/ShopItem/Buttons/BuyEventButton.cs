using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Shop.Scenes.Base.UI.ShopItem.Buttons
{
    public sealed class BuyEventButton :  MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TMP_Text buttonText;
        
        private bool _isActive = true;
        
        private const string ActiveStateText = "Buy";
        private const string UnactiveStateText = "Unnactive";
        private const string ConnectStateText = "Connect";
        
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.dragging) return;
            if (!_isActive) return;
        }
        public void SetState(bool isActive)
        {
            _isActive = isActive; 
            buttonText.text = _isActive ? ActiveStateText : UnactiveStateText;
        }
    }
}