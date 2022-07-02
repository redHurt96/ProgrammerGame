using System.Collections;
using _Game.Common;
using _Game.Data;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;
using RH.Utilities.Coroutines;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Logic.Systems
{
    public class ResetForBoostSystem : BaseInitSystem
    {
        public override void Init() => 
            EventsMediator.Instance.ResetForBoostIntent += ResetProgressForBoost;

        public override void Dispose() => 
            EventsMediator.Instance.ResetForBoostIntent -= ResetProgressForBoost;

        private void ResetProgressForBoost(float boost) => 
            CoroutineLauncher.Start(ResetAfterDelay(boost));

        private IEnumerator ResetAfterDelay(float boost)
        {
            PlayerPrefs.DeleteKey("Save");
            PlayerPrefs.SetInt("Need reset", 1);
            PlayerPrefs.Save();

            yield return null;

            GameData.Instance.PersistentData.MainBoost += boost;

            SceneManager.LoadScene(0);
        }
    }
}