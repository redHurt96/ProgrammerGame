using TMPro;
using UnityEngine;

namespace _Game.Fx
{
    public class PriceFx : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _amount;

        public void SetPrice(string value) => 
            _amount.text = value;
    }
}
