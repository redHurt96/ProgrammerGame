using System.Collections.Generic;
using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    [CreateAssetMenu(fileName = "Environment", menuName = "Game/Environment", order = 1)]
    public class EnvironmentAssets : ScriptableObject
    {
        public House[] Houses;
    }
}