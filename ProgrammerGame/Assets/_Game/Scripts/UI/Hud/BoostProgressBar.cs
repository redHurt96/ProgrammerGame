using _Game.Data;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Hud
{
    public class BoostProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _bar;
        
        private GameData _data;

        private void Start()
        {
            _data = Services.Get<GameData>();
            
            UpdateText();
        }

        private void Update() => 
            UpdateText();

        private void UpdateText() =>
            _bar.fillAmount = _data.ResetProgress();
    }
}