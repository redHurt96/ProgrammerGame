using UnityEngine;

namespace _Game.Scripts.UI.Main
{
    public class PanelWithTabs : MonoBehaviour
    {
        [SerializeField] private MainPanelTab[] _tabs;

        public void Select(TabName tabName)
        {
            foreach (MainPanelTab tab in _tabs)
                tab.SetActive(tab.Name == tabName);
        }
    }
}