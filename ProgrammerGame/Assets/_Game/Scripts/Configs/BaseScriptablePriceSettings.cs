using UnityEngine;

namespace _Game.Configs
{
    public abstract class BaseScriptablePriceSettings : ScriptableObject
    {
        public abstract double GetPrice(int level);
    }
}