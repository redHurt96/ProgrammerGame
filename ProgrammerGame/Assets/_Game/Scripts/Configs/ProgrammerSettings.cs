using UnityEngine;

namespace _Game.Configs
{
    [CreateAssetMenu(fileName = "Programmer settings", menuName = "Game/Programmer settings", order = 0)]
    public class ProgrammerSettings : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public ProjectSettings AutomatedProject;

        [SerializeField] private PriceSettings _priceSettings;

        public double GetPrice(int level) => 
            _priceSettings.GetPrice(level);
    }
}