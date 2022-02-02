using UnityEngine;

namespace AP.ProgrammerGame.Logic
{
    public class CharacterMaterialColorChanger : MonoBehaviour
    {
        [SerializeField] private int _materialIndex = 0;
        [SerializeField] private Color[] _possibleColors;

        private Material _material;

        private void Start()
        {
            ChangeColor();
            Destroy(this);
        }

        private void ChangeColor()
        {
            _material = GetComponent<SkinnedMeshRenderer>().materials[_materialIndex];
            _material.color = GetRandomColor();
        }

        private Color GetRandomColor()
        {
            var index = Random.Range(0, _possibleColors.Length);
            return _possibleColors[index];
        }
    }
}