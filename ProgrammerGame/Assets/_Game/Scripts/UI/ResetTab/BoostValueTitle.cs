using _Game.Data;
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
            if (GameData.Instance == null)
                return;

            _text.text = "x " + GameData.Instance.FullResetBoost().ToString("F1");
        }
    }
}