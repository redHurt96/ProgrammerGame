using _Game.Data;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.UI.Tutorial
{
    public class ProgrammersTabUnblock : MonoBehaviour
    {
        private void Start() => 
            Services.Get<GameData>().SavableData.IsProgrammersTabUnlocked = true;
    }
}