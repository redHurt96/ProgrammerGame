namespace AP.ProgrammerGame.Logic
{
    public interface IUpgradeManager
    {
        bool CanBuy { get; }
        void Buy();
        int CalculatePrice();
    }
}