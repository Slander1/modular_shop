using System;

namespace Core.Utility.UI
{
    public abstract class LabeledTextPanelBase : TextPanelBase
    {
        protected abstract string Label { get; }
        
        public override void UpdateText(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Text cannot be null or empty");
            
            textField.text = $"{Label} : {text}";
        }
    }
    
}