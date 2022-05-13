using RH.Utilities.UI;
using UnityEngine.SceneManagement;

namespace _Game.Debug
{
    public class ClearDataCheatButton : BaseActionButton
    {
        protected override void PerformOnClick() => 
            SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}