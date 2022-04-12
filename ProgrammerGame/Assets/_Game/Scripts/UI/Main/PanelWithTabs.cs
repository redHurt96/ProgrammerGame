using System;
using _Game.Scripts.UI.Main;
using UnityEngine;

namespace _Game.UI.Main
{
    public class PanelWithTabs : MonoBehaviour
    {
        [SerializeField] private TabGroup[] _tabs;

        public void Select(TabName tabName)
        {
            foreach (TabGroup tab in _tabs)
                tab.SetActive(tab.Name == tabName);
        }

        [Serializable]
        private class TabGroup
        {
            public TabName Name;

            [SerializeField] private GameObject _activeImage;
            [SerializeField] private GameObject _tab;

            public void SetActive(bool state)
            {
                _tab.gameObject.SetActive(state);
                _activeImage?.gameObject.SetActive(state);
            }
        }
    }
}