using System;
using UnityEngine;

namespace AP.ProgrammerGame_v2
{
    [CreateAssetMenu(fileName = "CodeSourcesArray", menuName = "Game/V2/CodeSourcesArray", order = 1)]
    public class CodeSourcesArray : ScriptableObject
    {
        [SerializeField] private CodeSource[] _codeSources;

        public string Current => _codeSources[_index].Source;

        private int _index;

        public string GetNext()
        {
            IncreaseIndex();
            return Current;
        }

        private void IncreaseIndex()
        {
            _index++;
            _index %= _codeSources.Length;
        }

        [Serializable]
        private class CodeSource
        {
            [TextArea(10, 30)] public string Source;
        }
    }
}