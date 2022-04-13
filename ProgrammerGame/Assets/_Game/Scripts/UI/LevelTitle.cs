using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI
{
    public class LevelTitle : MonoBehaviour
    {
        [SerializeField] private Text _title;

        private void Start()
        {
            UpdateTitle();

            GlobalEvents.LevelChanged += UpdateTitle;
        }

        private void OnDestroy() => 
            GlobalEvents.LevelChanged -= UpdateTitle;

        private void UpdateTitle() => 
            _title.text = GameData.Instance.SavableData.Level.ToString();
    }
}