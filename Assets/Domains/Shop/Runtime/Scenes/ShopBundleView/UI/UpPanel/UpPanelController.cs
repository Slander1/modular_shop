using Shop.Scenes.ShopBundleView.UI.UpPanel.Buttons;
using UnityEngine;

namespace Shop.Scenes.ShopBundleView.UI.UpPanel
{
    public sealed class UpPanelController : MonoBehaviour
    {
        [SerializeField] private BackButton backButton;

        private ShopBundleViewScenesAdapter _scenesAdapter;

        #region === Unity Events ===

        private void OnEnable()
        {
            backButton.Clicked += BackButtonOnClicked;
        }

        private void OnDisable()
        {
            backButton.Clicked -= BackButtonOnClicked;
        }

        #endregion === Unity Events ===
        
        public void Construct(ShopBundleViewScenesAdapter scenesAdapter)
        {
            _scenesAdapter = scenesAdapter;
        }
        
        private void BackButtonOnClicked()
        {
            _scenesAdapter.OnBackClick();
        }
    }
}