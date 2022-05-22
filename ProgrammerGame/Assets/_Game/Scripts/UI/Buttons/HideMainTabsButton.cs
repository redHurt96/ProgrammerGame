using _Game.UI.Main;
using RH.Utilities.UI;
using UnityEngine;

namespace _Game.UI.Buttons
{
    public class HideMainTabsButton : BaseActionButton
    {
        [SerializeField] private PanelWithTabs _panel;

        protected override void PerformOnStart() => 
            _panel.TabSelected += Enable;

        protected override void PerformOnDestroy() => 
            _panel.TabSelected -= Enable;

        protected override void PerformOnClick()
        {
            _panel.HideAll();

            gameObject.SetActive(false);
        }

        private void Enable() => 
            gameObject.SetActive(true);
    }
}