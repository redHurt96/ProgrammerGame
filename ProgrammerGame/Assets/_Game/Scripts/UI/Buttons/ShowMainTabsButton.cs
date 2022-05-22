using _Game.UI.Main;
using RH.Utilities.UI;
using UnityEngine;

namespace _Game.UI.Buttons
{
    public class ShowMainTabsButton : BaseActionButton
    {
        [SerializeField] private PanelWithTabs _panel;
        [SerializeField] private TabName _tab;

        protected override void PerformOnClick() => 
            _panel.Select(_tab);
    }
}