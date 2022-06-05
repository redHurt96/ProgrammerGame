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
            GlobalEvents.Instance.ResetForBoostIntent += ResetProgressForBoost;

        public override void Dispose() => 
            GlobalEvents.Instance.ResetForBoostIntent -= ResetProgressForBoost;

        private void ResetProgressForBoost() => 
            CoroutineLauncher.Start(ResetAfterDelay());

        private IEnumerator ResetAfterDelay()
        {
            PlayerPrefs.DeleteKey("Save");
            PlayerPrefs.SetInt("Need reset", 1);
            PlayerPrefs.Save();

            yield return null;

            GameData.Instance.PersistentData.MainBoost = GameData.Instance.BoostForProgress() *
                                                         GameData.Instance.PersistentData.MainBoost;

            SceneManager.LoadScene(0);
        }
    }
}