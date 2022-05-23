using System.Linq;
using _Game.Data;
using _Game.GameServices;
using _Game.Tutorial;
using _Game.UI.Tutorial;
using RH.Utilities.ServiceLocator;
using RH.Utilities.UI;
using UnityEngine;

namespace _Game.Debug
{
    public class SkipTutorialButton : BaseActionButton
    {
        private TutorialSettings _tutorialSettings;
        private GameData _data;
        private WindowsManager _windowsManager;
        private TutorialEvents _tutorialEvents;

        protected override void PerformOnStart()
        {
            _tutorialSettings = Services.Get<TutorialSettings>();
            _tutorialEvents = Services.Get<TutorialEvents>();
            _windowsManager = Services.Get<WindowsManager>();
            _data = Services.Get<GameData>();
        }

        protected override void PerformOnClick()
        {
            _tutorialEvents.ClearTutorial();

            if (_windowsManager.IsAnyWindowShown && _windowsManager.TopWindow is TutorialWindow tutorialWindow) 
                _windowsManager.Hide(tutorialWindow);

            FindObjectsOfType<Canvas>(true)
                .First(x => x.gameObject.name == "Tutorials")
                .gameObject.SetActive(false);

            _tutorialSettings.Background.SetActive(false);

            _data.PersistentData.IsProgrammersTabUnlocked = true;
            _data.PersistentData.IsUpgradesTabUnlocked = true;
        }
    }
}