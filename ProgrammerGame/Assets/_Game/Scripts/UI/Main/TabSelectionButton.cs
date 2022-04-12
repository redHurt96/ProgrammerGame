using _Game.Scripts.UI.Main;
using RH.Utilities.UI;
using UnityEngine;

namespace _Game.UI.Main
{
    public class TabSelectionButton : BaseActionButton
    {
        public TabName Name => _name;
        
        [SerializeField] private TabName _name;
        [SerializeField] private PanelWithTabs _panelWithTabs;

        public void SelectTab() => 
            _panelWithTabs.Select(_name);

        protected override void PerformOnClick() => 
            SelectTab();
    }
}