namespace _Game.UI.Tutorial
{
    public class UpgradesTabBlockedButton : AbstractBlockedButton
    {
        protected override bool Condition => _data.PersistentData.IsUpgradesTabUnlocked;
    }
}