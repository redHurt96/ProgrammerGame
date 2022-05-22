using System;
using UnityEngine;

namespace _Game.Data
{
    [Serializable]
    public class ProgrammerUpgradeData : IDisposable
    {
        public event Action<string> Upgraded; 

        public string ProjectName;
        public int Level => _upgradeData.Level;

        [SerializeField] private UpgradeData _upgradeData;

        public ProgrammerUpgradeData(string projectName)
        {
            ProjectName = projectName;

            _upgradeData = new UpgradeData();
            _upgradeData.Upgraded += TriggerSelfEvent;
        }

        public void Upgrade() => _upgradeData.Upgrade();

        public void Dispose() => 
            _upgradeData.Upgraded -= TriggerSelfEvent;

        private void TriggerSelfEvent() => 
            Upgraded?.Invoke(ProjectName);
    }
}