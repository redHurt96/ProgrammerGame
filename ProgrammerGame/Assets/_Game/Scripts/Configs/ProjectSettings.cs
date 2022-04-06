using System;
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

        [SerializeField] private PriceSettings priceSettings;
        [SerializeField] private PriceSettings incomeSettings;
        [SerializeField] private TimeSettings timeSettings;

        public long GetPrice(int forLevel) => priceSettings.GetPrice(forLevel);
        public long GetIncome(int forLevel) => incomeSettings.GetPrice(forLevel);
        public long GetTime(int forLevel) => timeSettings.GetTime(forLevel);
    }
}