using System;
using System.Linq;
using _Game.Common;
using _Game.Configs;
using _Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace _Game.UI.UpgradesTab
{
    public class InteriorUpgradePanel : BaseUpgradePanel
    {
        [SerializeField] private Text _tip;
        
        protected override string EffectTitle => $"+{(int)(Settings.Instance.IncreaseSpeedEffectStrength * 100)}% speed";
        protected override string TotalEffectTitle => $"+{GameData.Instance.IncreaseSpeedTotalEffect() * 100}% speed";
        protected override bool CheckAdditionalBuyAvailability() => true;
    }
}