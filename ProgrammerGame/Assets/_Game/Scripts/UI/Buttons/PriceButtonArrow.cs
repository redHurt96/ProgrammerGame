using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.Buttons
{
    public class PriceButtonArrow : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        private void Update() => 
            _image.enabled = _button.interactable;
    }
}