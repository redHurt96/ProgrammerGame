using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.UI.Projects
{
    public class NotAvailableContent : MonoBehaviour
    {
        [SerializeField] private Text _name;
        [SerializeField] private Text _openCondition;

        public void Setup(ProjectSettings settings, ProjectSettings previousProjectSettings)
        {
            _name.text = settings.Name;

            if (previousProjectSettings != null)
                _openCondition.text = $"need {settings.OpenLevel} {previousProjectSettings.Name}";
            else
                _openCondition.gameObject.SetActive(false);
        }
    }
}