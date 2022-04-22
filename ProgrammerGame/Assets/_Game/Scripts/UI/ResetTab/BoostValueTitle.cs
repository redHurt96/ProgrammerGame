using _Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ResetTab
{
    [RequireComponent(typeof(Text))]
    public class BoostValueTitle : MonoBehaviour
    {
        [SerializeField] private Text _text;

        private void OnEnable() => 
            UpdateTitle();

        private void UpdateTitle()
        {
            if (_gameDataPresenter == null)
                return;

            _text.text = "x " + _gameDataPresenter.BoostForProgress.ToString("F2");
        }
    }
}