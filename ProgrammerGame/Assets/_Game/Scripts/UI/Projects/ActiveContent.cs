using System.Linq;
using _Game.Scripts.Exception;
using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.UI.Projects
{
    public class ActiveContent : MonoBehaviour
    {
        [SerializeField] private Text _level;
        [SerializeField] private Text _income;
        [SerializeField] private Text _price;
        [SerializeField] private Image _progressBarFill;
        [SerializeField] private Text _timer;

        private ProjectData _projectData;

        public void Setup(ProjectData projectData)
        {
            _projectData = projectData;

            UpdateTitles();
            UpdateContent();
            Subscribe();
        }

        private void Subscribe()
        {
            _projectData.ProgressUpdated += UpdateContent;
            _projectData.Finished += UpdateTitles;
        }

        private void OnDestroy()
        {
            _projectData.ProgressUpdated -= UpdateContent;
            _projectData.Finished -= UpdateTitles;
        }

        private void UpdateTitles()
        {
            _level.text = $"{_projectData.Level}/{GetCloseLevelTarget(_projectData.Level)}";
            _income.text = _projectData.Income.ToPriceString();
            _price.text = _projectData.Price.ToPriceString();
        }

        private void UpdateContent()
        {
            _progressBarFill.fillAmount = _projectData.Progress;
            _timer.text = _projectData.TimeToFinish.ToString("h:mm:ss");
        }

        private string GetCloseLevelTarget(int level) =>
            Settings.Instance.TargetLevels
                .First(x => x > level)
                .ToString();
    }
}