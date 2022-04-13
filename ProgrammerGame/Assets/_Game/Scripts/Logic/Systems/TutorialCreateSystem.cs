using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Tutorial;
using RH.Utilities.ComponentSystem;

namespace _Game.Logic.Systems
{
    public class TutorialCreateSystem : IInitSystem
    {
        public void Init()
        {
            foreach (TutorialSettings.Setting setting in TutorialSettings.Instance.Settings)
            {
                if (!GameData.Instance.TutorialData.Steps.Contains(setting.Name))
                    TutorialEvents.Instance.CreateActionFrom(setting);
            }
        }
    }
}