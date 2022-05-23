using _Game.Configs;
using _Game.Data;
using RH.Utilities.ServiceLocator;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.ProjectsTab
{
    public class ProjectProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _fill;
        [SerializeField] private GameObject _arrow;

        private Settings _settings;
        private GameData _data;

        private bool _isIdleProgressBarSetup = false;

        private void OnEnable()
        {
            _settings ??= Services.Get<Settings>();
            _data ??= Services.Get<GameData>();
        }

        public void UpdateContent(ProjectData projectData)
        {
            if (projectData.Time > _settings.ChangeProgressBarAnchorTime)
                FillProgressBar(projectData.Progress);
            else if (!_isIdleProgressBarSetup && _data.IsProjectAutoRunned(projectData.Name))
                SetupIdleProgressBar();
        }

        private void SetupIdleProgressBar()
        {
            _fill.fillAmount = 1f;
            _arrow.SetActive(true);
        }

        private void FillProgressBar(float progress) => 
            _fill.fillAmount = progress;
    }
}