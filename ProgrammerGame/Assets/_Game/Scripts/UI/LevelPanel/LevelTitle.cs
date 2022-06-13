using _Game.Common;
using _Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.LevelPanel
{
    public class LevelTitle : MonoBehaviour
    {
        [SerializeField] private Text _title;

        private void Start()
        {
            UpdateTitle();

            EventsMediator.Instance.LevelChanged += UpdateTitle;
        }

        private void OnDestroy() => 
            EventsMediator.Instance.LevelChanged -= UpdateTitle;

        private void UpdateTitle() => 
            _title.text = GameData.Instance.PersistentData.Level.ToString();
    }
}