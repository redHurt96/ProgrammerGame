using _Game.Common;
using _Game.Data;
using RH.Utilities.ComponentSystem;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class PassedTutorialsSaveSystem : BaseInitSystem
    {
        private const string PASSED_TUTORIALS_KEY = "PassedTutorials";

        public override void Init()
        {
            if (PlayerPrefs.HasKey(PASSED_TUTORIALS_KEY))
            {
                GameData.Instance.TutorialData =
                    JsonUtility.FromJson<TutorialData>(PlayerPrefs.GetString(PASSED_TUTORIALS_KEY));
            }

            GlobalEvents.TutorialStepPerformed += Save;
        }

        public override void Dispose() => 
            GlobalEvents.TutorialStepPerformed -= Save;

        private void Save()
        {
            string data = JsonUtility.ToJson(GameData.Instance.TutorialData);

            PlayerPrefs.SetString(
                PASSED_TUTORIALS_KEY, 
                data);

            PlayerPrefs.Save();
        }
    }
}