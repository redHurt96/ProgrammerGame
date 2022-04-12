using System.Linq;
using _Game.UI.Main;
using UnityEngine;

namespace _Game.Scripts.UI.Main
{
    public class TapMenu : MonoBehaviour
    {
        [SerializeField] private TabSelectionButton[] _buttons;
        [SerializeField] private TabName _firstSelectedTab;

        private void Start() =>
            _buttons
                .First(x => x.Name == _firstSelectedTab)
                .SelectTab();
    }
}