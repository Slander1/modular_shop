using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Utility.UI
{
    public abstract class EventButtonBase : MonoBehaviour, IPointerClickHandler
    {
        public event Action Clicked;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke();
        }
    }
}