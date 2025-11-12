using Core.Utility.Player;
using Core.Utility.UI;
using UnityEngine;

namespace Location.UI
{
    public class LocationPanel : MonoPlayerDataListenerBase<Data.Location, string>
    {
        [SerializeField] private LabeledTextPanelBase statView;
        
        protected override void OnPlayerDataChanged(string newValue)
        {
            UpdateData(newValue);
        }

        private void UpdateData(string newValue)
        {
            statView.UpdateText(newValue);
        }
    }
}