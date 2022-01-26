using RH.Utilities.SingletonAccess;

namespace AP.ProgrammerGame_v2
{
    public class GameData : Singleton<GameData>
    {
        public float CodeWritingTime = 5f;
        public float CodeWritingProgress = 0f;

        public float MoneyForCode = 1f;
        public float MoneyForBug = 5f;

        public float MoneyCount = 0f;

        public float AccelerationCodeProgressPercent = .05f;
    }
}