using _Game.Common;
using _Game.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.UI
{
    public class CodeWritingPanelSingleImage : MonoBehaviour
    {
        [SerializeField] private Image _codeImage;

        private void Start() => 
            GlobalEvents.CodeWritten += Write;

        private void OnDestroy() => 
            GlobalEvents.CodeWritten -= Write;

        private void Write() => 
            _codeImage.fillAmount = GameData.Instance.CodeWritingProgress;
    }
}