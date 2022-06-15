using System;
using _Game.Fx;
using _Game.Logic.MonoBehaviours;
using UnityEngine;

namespace _Game.Configs
{
    [Serializable]
    public class FxConfigs
    {
        public Money[] MoneyPrefabs;
        public PriceFx TapFxPrefab;
        public GameObject TapFxPrefab2;
        public GameObject FurnitureSpawnFxPrefab;
        public GameObject Pizza;
        public GameObject DiscoBall;
        public float PizzaSpawnTime = 2f;
    }
}