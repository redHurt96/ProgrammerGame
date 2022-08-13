using _Game.Configs;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Common
{
    public class BootEntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            PlayerPrefs.SetInt(Settings.INCREASE_SESSIONS_COUNT_INTENT, 1);
            SceneManager.LoadScene("Main");
        }
    }
}