using RH.Utilities.UI;
using UnityEngine;
using UnityEngine.UI;

namespace AP.ProgrammerGame.UI
{
    [RequireComponent(typeof(Image))]
    public class CatchBugButton : BaseActionButton
    {
        public Vector2 AnchoredPosition
        {
            get => _rectTransform.anchoredPosition;
            set => _rectTransform.anchoredPosition = value;
        }

        private RectTransform _rectTransform;
        private Image _image;

        private void Awake()
        {
            _rectTransform = transform as RectTransform;
            _image = GetComponent<Image>();
        }

        public void Enable() => SetActive(true);

        public void Rotate(Vector2 direction)
        {
            float angle = Vector2.SignedAngle(transform.up, direction);
            Debug.Log(angle);
            _rectTransform.Rotate(0f, 0f, angle);
            //_rectTransform.Rotate(0f, 0f, angle);
            //_rectTransform.up = direction;
        }

        protected override void PerformOnClick()
        {
            GlobalEvents.CatchBug();
            Disable();
        }

        private void Disable() => SetActive(false);

        private void SetActive(bool isActive)
        {
            _image.enabled = isActive;
            _image.raycastTarget = isActive;
        }
    }
}