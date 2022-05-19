using System;
using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.GameServices;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;
using RH.Utilities.ServiceLocator;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class IdleIncomeSystem : IInitSystem
    {
        private readonly WindowsManager _windowsManager;
        private readonly GameData _data;
        private readonly Settings _settings;
        private readonly SceneObjects _sceneObjects;

        public IdleIncomeSystem()
        {
            _windowsManager = Services.Get<WindowsManager>();
            _data = Services.Get<GameData>();
            _settings = Services.Get<Settings>();
            _sceneObjects = Services.Get<SceneObjects>();
        }

        public void Init()
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime quitTime = DateTime.FromBinary(_data.SavableData.SaveDateTime);
            double idleTime = Mathf.Min((float) currentDateTime.Subtract(quitTime).TotalSeconds, _settings.IdleIncomeSeconds);
            long autorunnedProjectsIncomePerSecond = (long) _data.SavableData.Projects
                .Where(x => _data.IsProjectAutoRunned(x.Name))
                .Sum(x => Mathf.Max((float) x.Income / x.Time, 1f));
            long income = (long) (idleTime * autorunnedProjectsIncomePerSecond);

            if (income > 0)
                _windowsManager
                    .Show(_sceneObjects.EarnedWhileAwayWindow)
                    .SetCount(income);
        }
    }
}