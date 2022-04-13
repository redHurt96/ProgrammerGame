using _Game.Common;
using _Game.Configs;
using _Game.Data;
using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.UI
{
    public class CodeWritingPanelMultiImage : MonoBehaviour
    {
        [SerializeField] private Image[] _codeImages;

        private void Start()
        {
            PrepareImages();
            GlobalEvents.CodeWritten += Write;
            GlobalEvents.CodeWrittenComplete += ClearCode;
        }

        private void OnDestroy()
        {
            GlobalEvents.CodeWritten -= Write;
            GlobalEvents.CodeWrittenComplete -= ClearCode;
        }

        [ContextMenu(nameof(PrepareImages))]
        private void PrepareImages()
        {
            _codeImages = GetComponentsInChildren<Image>();
            ClearCode();
        }

        private void Write()
        {
            var progress = GameData.Instance.CodeWritingProgress;
            var fillValue = progress * _codeImages.Length;

            for (int i = 0; i < _codeImages.Length; i++)
            {
                Image image = _codeImages[i];
                int fillValueInt = (int) fillValue;

                if (i < fillValueInt && image.fillAmount < 1f)
                {
                    image.fillAmount = 1;
                }
                else if (i == fillValueInt)
                {
                    image.fillAmount = fillValue - fillValueInt;
                    break;
                }
            }
        }

        private void ClearCode()
        {
            foreach (var image in _codeImages)
                image.fillAmount = 0f;
        }
    }
}