using System;
using TMPro;
using UnityEngine;

namespace Core.Utility.UI
{
    public abstract class TextPanelBase : MonoBehaviour
    {
        [SerializeField] protected TMP_Text textField;

        public void UpdateText(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Text cannot be null or empty");
            textField.text = text;
        }
    }
}