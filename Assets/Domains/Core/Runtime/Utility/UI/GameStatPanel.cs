using Core.Data.Player.Stats;
using Core.Utility.Player;
using UnityEngine;

namespace Core.Utility.UI
{
    public abstract class GameStatPanel<TKey, TValue> : MonoPlayerDataListenerBase<TKey, TValue>
        where TKey : class, ITypedPlayerStat<TValue>, new()
    {
        [SerializeField] private EventButtonBase addStatButton;
        [SerializeField] private LabeledTextPanelBase statView;
        
        [Space] 
        [SerializeField] private TValue addAmountBuyClick;
        
        protected override void OnEnable()
        {
            base.OnEnable();
            addStatButton.Clicked += OnClickedAddButton;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            addStatButton.Clicked -= OnClickedAddButton;
        }
        
        private void OnClickedAddButton()
        {
            Data.UpdateValue<TKey, TValue>(addAmountBuyClick);
        }
        
        protected override void OnPlayerDataChanged(TValue newValue)
        {
            UpdateData(newValue);
        }

        private void UpdateData(TValue newValue)
        {
            statView.UpdateText(newValue.ToString());
        }
    }
}