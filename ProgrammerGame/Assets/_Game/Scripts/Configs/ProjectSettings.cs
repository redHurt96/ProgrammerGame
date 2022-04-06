using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Project settings", menuName = "Game/Project settings", order = 0)]
    public class ProjectSettings : ScriptableObject
    {
        public string Name;
        public Sprite Icon;

        public int OpenLevel = 0;
        public ProjectSettings BlockProject;

        public long GetPrice(int forLevel) => _priceSettings.GetPrice(forLevel);
        public long GetIncome(int forLevel) => _incomeSettings.GetPrice(forLevel);
        public long GetTime(int forLevel) => _timeSettings.GetTime(forLevel);

        [SerializeField] private PriceSettings _priceSettings;
        [SerializeField] private PriceSettings _incomeSettings;
        [SerializeField] private TimeSettings _timeSettings;
    }
}