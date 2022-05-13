using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Game.Debug
{
    public class ClearDataAndLoadFirstScene : MonoBehaviour
    {
        private void Awake()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();

            SceneManager.LoadScene(0);
        }
    }
}