using RH.Utilities.PseudoEcs;
using UnityEngine.SceneManagement;

namespace _Game.Logic.Systems
{
    public class LoadGameSceneSystem : IInitSystem
    {
        public void Init() => 
            SceneManager.LoadScene("Main");
    }
}