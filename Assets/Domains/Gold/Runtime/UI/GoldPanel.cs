using Core.Utility.Player;
using Gold.Data;
using Gold.UI.Buttons;
using UnityEngine;

namespace Gold.UI
{
    public class GoldPanel : MonoPlayerDataListenerBase
    {
        [SerializeField] private AddGoldButton addGoldButton;
        [SerializeField] private GoldPanelTextView goldAmountTextView;

        [Space] 
        [SerializeField] private int addGoldAmoundForClickOnPlus = 100;

        #region === Unity Events ===

        protected override void OnEnable()
        {
            base.OnEnable();
            addGoldButton.Clicked += AddGoldButtonOnClicked;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            addGoldButton.Clicked -= AddGoldButtonOnClicked;
        }

        #endregion === Unity Events ===
        
        protected override void OnPlayerDataChanged()
        {
            UpdateData();
        }

        private void UpdateData()
        {
            var newGoldAmount = Data.GetValue<GoldAmount, int>();
            goldAmountTextView.UpdateText(newGoldAmount.ToString());
        }
        
        private void AddGoldButtonOnClicked()
        {
            Data.UpdateValue<GoldAmount, int>(addGoldAmoundForClickOnPlus);
        }
    }
}