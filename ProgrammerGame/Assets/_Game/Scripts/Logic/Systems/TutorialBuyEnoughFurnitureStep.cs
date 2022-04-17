﻿using _Game.Common;
using _Game.Configs;
using _Game.Data;

namespace _Game.Logic.Systems
{
    public class TutorialBuyEnoughFurnitureStep : BaseTutorialWaitForStepSystem
    {
        protected override TutorialStep Step => TutorialStep.BuyEnoughFurniture_8;

        protected override bool _waitCondition =>
            GameData.Instance.TutorialData.Steps.Contains(TutorialStep.UpgradePcOrFurniture_7)
            && (GameDataPresenter.Instance.GetUpgradeData(UpgradeType.PC).Level > 0 ||
                GameDataPresenter.Instance.GetUpgradeData(UpgradeType.Interior).Level > 0);

        protected override float _delay => 1f;
    }
}