using _Game.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.UI.Projects
{
    public class NotAvailableContent : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Text _name;
        [SerializeField] private Text _openCondition;

        public void Setup(ProjectSettings settings)
        {
            _icon.sprite = settings.Icon;
            _name.text = settings.Name;

            if (settings.BlockProject != null)
                _openCondition.text = $"need {settings.OpenLevel} {settings.BlockProject.Name}";
            else
                _openCondition.gameObject.SetActive(false);
        }
    }
}