using System;
using UnityEngine;

namespace _Game.UI.Main
{
    [Serializable]
    public class MainPanelTab : MonoBehaviour
    {
        public void SetActive(bool state) => 
            gameObject.SetActive(state);
    }

    public enum TabName
    {
        Projects = 0,
        Upgrades,
        Programmers,

        Python,
        CSharp,
        CPlusPlus,
    }
}