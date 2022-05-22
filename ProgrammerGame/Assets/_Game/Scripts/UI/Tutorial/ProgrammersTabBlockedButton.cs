namespace _Game.UI.Tutorial
{
    public class ProgrammersTabBlockedButton : AbstractBlockedButton
    {
        protected override bool Condition => _data.PersistentData.IsProgrammersTabUnlocked;
    }
}