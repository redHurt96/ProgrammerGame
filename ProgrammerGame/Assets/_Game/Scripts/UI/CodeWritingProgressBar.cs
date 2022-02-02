using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.UI
{
    public class CodeWritingProgressBar : MonoBehaviour
    {
        [SerializeField] private Image _image;

        private void Start() => GlobalEvents.CodeWritten += UpdateBar;
        private void OnDestroy() => GlobalEvents.CodeWritten -= UpdateBar;

        private void UpdateBar() => _image.fillAmount = GameData.Instance.CodeWritingProgress;
    }
}