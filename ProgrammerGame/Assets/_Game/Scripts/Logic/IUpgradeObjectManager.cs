namespace AP.ProgrammerGame.Logic
{
    public interface IUpgradeObjectManager
    {
        bool CanUpgrade { get; }
        void Upgrade();
    }
}