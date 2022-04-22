using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using _Game.UI.Tutorial;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class TutorialCreateSystem : IInitSystem
    {
        public void Init()
        {
            foreach (TutorialWindow window in TutorialSettings.Instance.Windows)
            {
                if (!GameData.Instance.PersistentData.TutorialData.Steps.Contains(window.Step))
                    TutorialEvents.Instance.CreateActionFrom(window);
            }
        }
    }
}