using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Characters
{
    public class ColorRandomizer : MonoBehaviour
    {
        [SerializeField] private PossibleColors[] _possibleColors;

        private void Start()
        {
            Dictionary<string, Color> randomColors = new Dictionary<string, Color>();

            foreach (PossibleColors color in _possibleColors)
                randomColors.Add(color.Name, color.GetRandom());

            Material[] materials = GetComponentsInChildren<SkinnedMeshRenderer>()
                .SelectMany(x => x.materials)
                .ToArray();

            foreach (Material material in materials)
            {
                material.color = randomColors
                    .First(x => material.name.Contains(x.Key))
                    .Value;
            }
        }

        [Serializable]
        private class PossibleColors
        {
            [SerializeField] private Material _material;
            [SerializeField] private Color[] _colors;

            public string Name => _material.name;

            public Color GetRandom() => 
                _colors[Random.Range(0, _colors.Length)];
        }
    }
}
