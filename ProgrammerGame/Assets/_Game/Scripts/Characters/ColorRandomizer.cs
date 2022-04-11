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

        private List<Material> _materials = new List<Material>();

        private void Start()
        {
            Material[] materials = GetComponentsInChildren<SkinnedMeshRenderer>()
                .SelectMany(x => x.materials)
                .ToArray();

            foreach (Material material in materials)
            {
                if (_materials.All(x => x.name != material.name))
                {
                    _materials.Add(material);
                    
                    material.color = _possibleColors
                        .First(x => material.name.Contains(x.Name))
                        .GetRandomColor();
                }
            }
        }

        [Serializable]
        private class PossibleColors
        {
            [SerializeField] private Material _material;
            [SerializeField] private Color[] _colors;

            public string Name => _material.name;

            public Color GetRandomColor() => 
                _colors[Random.Range(0, _colors.Length)];
        }
    }
}
