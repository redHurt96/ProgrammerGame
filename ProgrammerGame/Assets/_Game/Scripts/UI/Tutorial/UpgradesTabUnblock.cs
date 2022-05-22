using _Game.Data;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.UI.Tutorial
{
    public class UpgradesTabUnblock : MonoBehaviour
    {
        private void Start() => 
            Services.Get<GameData>().PersistentData.IsUpgradesTabUnlocked = true;
    }
}