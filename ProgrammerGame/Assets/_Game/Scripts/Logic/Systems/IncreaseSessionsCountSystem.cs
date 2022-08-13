using _Game.Configs;
using _Game.Data;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class IncreaseSessionsCountSystem : IInitSystem
    {
        private readonly GameData _data;

        public IncreaseSessionsCountSystem() => 
            _data = Services.Get<GameData>();

        public void Init()
        {
            if (PlayerPrefs.HasKey(Settings.INCREASE_SESSIONS_COUNT_INTENT))
            {
                _data.PersistentData.SessionsCount++;
                
                PlayerPrefs.DeleteKey(Settings.INCREASE_SESSIONS_COUNT_INTENT);
                PlayerPrefs.Save();
            }
        }
    }
}