using _Game.Scripts.UI.Main;
using _Game.UI.Main;
using RH.Utilities.UI;
using UnityEngine;

namespace _Game.UI.Buttons
{
    public class HideMainTabsButton : BaseActionButton
    {
        [SerializeField] private PanelWithTabs _panel;
        [SerializeField] private TapMenu _tapMenu;

        protected override void PerformOnStart() => 
            _panel.TabSelected += Enable;

        protected override void PerformOnDestroy() => 
            _panel.TabSelected -= Enable;

        protected override void PerformOnClick()
        {
            _panel.HideAll();
            _tapMenu.DeselectAll();

            gameObject.SetActive(false);
        }

        private void Enable() => 
            gameObject.SetActive(true);
    }
}