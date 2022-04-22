using System;
using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using _Game.Services;
using AP.ProgrammerGame;
using RH.Utilities.PseudoEcs;
using UnityEngine;

namespace _Game.Logic.Systems
{
    public class IdleIncomeSystem : IInitSystem
    {
        public void Init()
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime quitTime = DateTime.FromBinary(GameData.Instance.SavableData.SaveDateTime);
            double idleTime = Mathf.Min((float) currentDateTime.Subtract(quitTime).TotalSeconds, Settings.Instance.IdleIncomeSeconds);
            long autorunnedProjectsIncomePerSecond = (long) GameData.Instance.SavableData.Projects
                .Where(x => GameData.Instance.SavableData.AutoRunnedProjects.Contains(x.Name))
                .Sum(x => Mathf.Max((float) x.Income / x.Time, 1f));
            long income = (long) (idleTime * autorunnedProjectsIncomePerSecond);

            if (income > 0)
                WindowsManager
                    .Show(SceneObjects.Instance._earnedWhileAwayWindow)
                    .SetCount(income);
        }
    }
}