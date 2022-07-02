using _Game.Data;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ResetTab
{
    [RequireComponent(typeof(Image))]
    public class ResetButtonVisibilityComponent : MonoBehaviour
    {
        [SerializeField] private Button _button;
        
        private GameData _data;

        private void Start() => 
            _data = Services.Get<GameData>();

        private void Update() =>
            _button.interactable = _data.CanReset();
    }
}