using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.UI
{
    public class MoneyCountText : MonoBehaviour
    {
        [SerializeField] private Text _text;

        private void Start() => 
            GlobalEvents.MoneyCountChanged += UpdateText;

        private void OnDestroy() => 
            GlobalEvents.MoneyCountChanged -= UpdateText;

        private void UpdateText(long l) => 
            _text.text = GameData.Instance.MoneyCount.ToString("F0");
    }
}