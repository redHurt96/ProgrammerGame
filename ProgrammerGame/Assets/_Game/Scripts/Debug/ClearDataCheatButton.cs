using RH.Utilities.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Debug
{
    public class ClearDataCheatButton : BaseActionButton
    {
        [SerializeField] private int _targetClickCount;

        private int _clickCount;

        protected override void PerformOnClick()
        {
            if (_targetClickCount == ++_clickCount)
            {
                _clickCount = 0;
                SceneManager.LoadScene("ClearDataScene");
            }
        }
    }
}