using Core.Data.Player;
using Core.Utility.Player;
using Core.Utility.UI;
using Location.Data.Scriptable;
using Location.UI.Buttons;
using UnityEngine;

namespace Location.UI
{
    public sealed class LocationPanel : MonoPlayerDataListenerBase<Data.Location, string>
    {
        [SerializeField] private LabeledTextPanelBase statView;
        [SerializeField] private LocationStatDefault locationStatDefault;
        [SerializeField] private ChangeLocationToDefaultButton changeLocationToDefaultButton;

        private IDataStorage _playerData;
        
        private void Construct()
        {
            _playerData = PlayerData.Instance;
        }
        
        #region === Unity Events ===

        protected override void Awake()
        {
            base.Awake();
            Construct();
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();
            changeLocationToDefaultButton.Clicked += OnClickedChangeLocationToDefaultButton;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            changeLocationToDefaultButton.Clicked -= OnClickedChangeLocationToDefaultButton;
        }

        #endregion  === Unity Events ===
        
        protected override void OnPlayerDataChanged(string newValue)
        {
            UpdateData(newValue);
        }

        private void UpdateData(string newValue)
        {
            statView.UpdateText(newValue);
        }
        
        private void OnClickedChangeLocationToDefaultButton()
        {
            _playerData.ReplaceValue<Data.Location, string>(locationStatDefault.Value);
        }
    }
}