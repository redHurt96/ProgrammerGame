using _Game.Data;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Tutorial
{
    [RequireComponent(typeof(Button))]
    public abstract class AbstractBlockedButton : MonoBehaviour
    {
        protected abstract bool Condition { get; }
        protected GameData _data;

        [SerializeField] private Button _button;

        private void Start() => 
            _data = Services.Get<GameData>();

        private void Update()
        {
            var condition = Condition;
            _button.interactable = condition;

            if (condition)
                Destroy(this);
        }
    }
}