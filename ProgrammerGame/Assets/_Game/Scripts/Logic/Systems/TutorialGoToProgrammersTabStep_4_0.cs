using _Game.Data;
using _Game.Tutorial;

namespace _Game.Logic.Systems
{
    public class TutorialGoToProgrammersTabStep_4_0 : BaseTutorialWaitForStepSystem
    {
        protected override TutorialStep Step => TutorialStep.GoToProgrammersTab_4_0;

        protected override bool _waitCondition =>
            _data.SavableData.MoneyCount >= _settings.AllProgrammersSettings.Programmers[0].GetPrice(0)
            && _data.ContainsTutorialStep(TutorialStep.BuyAnotherProject_6);

        protected override float _delay => 1f;
    }
}