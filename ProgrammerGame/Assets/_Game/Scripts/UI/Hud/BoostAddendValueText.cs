using _Game.Data;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Hud
{
    public class BoostAddendValueText : MonoBehaviour
    {
        [SerializeField] private Text _value;
        
        private GameData _data;

        private void Start()
        {
            _data = Services.Get<GameData>();
            
            UpdateText();
        }

        private void Update() => 
            UpdateText();

        private void UpdateText() => 
            _value.text = $"x{_data.FullResetBoost():F1}";
    }
}
