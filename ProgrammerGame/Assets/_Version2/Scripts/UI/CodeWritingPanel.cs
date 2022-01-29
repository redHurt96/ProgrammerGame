using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame_v2.UI
{
    public class CodeWritingPanel : MonoBehaviour
    {
        [SerializeField] private Text _code;

        [Space]
        [SerializeField] private CodeSourcesArray _sources;

        private string _source => _sources.Current;

        private void Start()
        {
            GlobalEvents.CodeWritten += Write;
            GlobalEvents.CodeWrittenComplete += UpdateSource;
        }

        private void OnDestroy()
        {
            GlobalEvents.CodeWritten -= Write;
            GlobalEvents.CodeWrittenComplete -= UpdateSource;
        }

        private void Write()
        {
            int symbolsCount = (int)(GameData.Instance.CodeWritingProgress * _source.Length);
            symbolsCount = Mathf.Min(symbolsCount, _source.Length);

            _code.text = _source.Substring(0, symbolsCount);
        }

        private void UpdateSource() => _sources.GetNext();
    }
}