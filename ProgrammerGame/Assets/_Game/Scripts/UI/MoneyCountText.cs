using _Game.Common;
using _Game.Scripts.Exception;
using AP.ProgrammerGame;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI
{
    public class MoneyCountText : MonoBehaviour
    {
        [SerializeField] private Text _text;

        private void Start() => 
            GlobalEvents.MoneyCountChanged += UpdateText;

        private void OnDestroy() => 
            GlobalEvents.MoneyCountChanged -= UpdateText;

        private void UpdateText(long l) =>
            _text.text = GameData.Instance.SavableData.MoneyCount.ToPriceString();
    }
}