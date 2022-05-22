using _Game.UI.Main;
using UnityEngine;

namespace _Game.UI.Tutorial
{
    public class SwitchToTab : MonoBehaviour
    {
        [SerializeField] private TabName _name;
        [SerializeField] private PanelWithTabs _tabs;

        private void Start() => 
            _tabs.Select(_name);
    }
}