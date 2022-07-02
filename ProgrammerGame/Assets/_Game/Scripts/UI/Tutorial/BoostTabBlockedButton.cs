namespace _Game.UI.Tutorial
{
    public class BoostTabBlockedButton : AbstractBlockedButton
    {
        protected override bool Condition => _data.PersistentData.IsBoostTabUnlocked;
    }
}