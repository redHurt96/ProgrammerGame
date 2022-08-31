using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Characters
{
    public class ColorRandomizer : MonoBehaviour
    {
        private float firstSaturationChange = -0.05f;
        private float firstValueChange = 0.1f;

        private float secondSaturationChange = 0.1f;
        private float secondValueChange = -0.2f;

        private float lightContribution = 0.2f;
        private float unityShadowPower = 0.3f;

        private float m_Hue;
        private float m_Saturation;
        private float m_Value;

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

                if (!material.HasProperty("_SelfShadingSize"))
                    material.shader = Shader.Find("FlatKit/Stylized Surface");

                Color.RGBToHSV(material.color, out m_Hue, out m_Saturation, out m_Value);

                material.SetColor("_BaseColor",
                    Color.HSVToRGB(m_Hue, m_Saturation + firstSaturationChange, m_Value + firstValueChange));
                material.SetColor("_ColorDim",
                    Color.HSVToRGB(m_Hue, m_Saturation + secondSaturationChange, m_Value + secondValueChange));

                material.SetFloat("_SelfShadingSize", 0.7f);
                material.SetFloat("_ShadowEdgeSize", 0f);
                material.SetFloat("_Flatness", 1.0f);

                material.SetFloat("_LightContribution", lightContribution);

                material.SetFloat("_UnityShadowMode", 1.0f);
                material.SetFloat("_UnityShadowPower", unityShadowPower);
                material.SetColor("_UnityShadowColor",
                    Color.HSVToRGB(m_Hue, m_Saturation + secondSaturationChange, m_Value + secondValueChange));
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
