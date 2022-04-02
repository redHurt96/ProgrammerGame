using System;
using UnityEngine;

namespace _Game.Scripts.UI.Main
{
    [Serializable]
    public class MainPanelTab : MonoBehaviour
    {
        public TabName Name;

        public void SetActive(bool state) => 
            gameObject.SetActive(state);

        //TODO: прокинуть ссылки на кнопки, когда нужно будет их подсвечивать
    }

    public enum TabName
    {
        Projects = 0,
        Upgrades,
        Programmers,

        Python,
        CSharp,
        CPlusPlus
    }
}