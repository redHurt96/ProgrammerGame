using System.Collections;
using _Game.Common;
using AP.ProgrammerGame;
using RH.Utilities.ComponentSystem;
using RH.Utilities.Coroutines;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Logic.Systems
{
    public class ResetForBoostSystem : BaseInitSystem
    {
        private const string NEED_RESET = "Need reset";
        private const string BOOST_KEY = "Boost";

        public override void Init()
        {
            GameData.Instance.MainBoost = PlayerPrefs.HasKey(BOOST_KEY) 
                ? PlayerPrefs.GetFloat(BOOST_KEY) 
                : 1f;

            GlobalEvents.ResetForBoostIntent += ResetProgressForBoost;
        }

        public override void Dispose() => 
            GlobalEvents.ResetForBoostIntent -= ResetProgressForBoost;

        private void ResetProgressForBoost() => 
            CoroutineLauncher.Start(ResetAfterDelay());

        private IEnumerator ResetAfterDelay()
        {
            yield return null;

            PlayerPrefs.DeleteKey("Save");
            PlayerPrefs.SetFloat(BOOST_KEY, GameDataPresenter.Instance.BoostForProgress * GameData.Instance.MainBoost);
            PlayerPrefs.SetInt(NEED_RESET, 1);
            PlayerPrefs.Save();

            SceneManager.LoadScene(0);
        }
    }
}