using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AP.ProgrammerGame.UI
{
    public class BugButtonMover : MonoBehaviour
    {
        [SerializeField] private CatchBugButton _bugButton;
        private float _moveTime => Settings.Instance.BugMoveTime;
        private Vector2 _sizeDelta;

        private WaitForSeconds _delay;

        private void Awake()
        {
            _sizeDelta = new Vector2(Screen.width, (transform as RectTransform).sizeDelta.y);
            _delay = new WaitForSeconds(Settings.Instance.BugMoveDelay);
        }

        private IEnumerator Start()
        {
            while (Application.isPlaying)
            {
                yield return _delay;
                yield return StartCoroutine(BugRun());
            }
        }

        private IEnumerator BugRun()
        {
            Vector2 startPosition = GetRandomPosition();
            Vector2 endPosition = GetEndPosition(startPosition);
            float currentMoveTime = 0f;

            PrepareBugButton(startPosition, endPosition);

            while (currentMoveTime < _moveTime)
            {
                _bugButton.AnchoredPosition = Vector2.Lerp(startPosition, endPosition, currentMoveTime / _moveTime);
                currentMoveTime += Time.deltaTime;

                yield return null;
            }
        }

        private Vector2 GetRandomPosition()
        {
            float x = _sizeDelta.x / 2f * (Mathf.Sign(Random.value - .5f));
            float y = Random.Range(-_sizeDelta.y / 2f, _sizeDelta.y / 2f);

            return new Vector2(x, y);
        }

        private Vector2 GetEndPosition(Vector2 startPosition)
        {
            float x = -startPosition.x;
            float y = Random.Range(-_sizeDelta.y / 2f, _sizeDelta.y / 2f);

            return new Vector2(x, y);
        }

        private void PrepareBugButton(Vector2 startPosition, Vector2 endPosition)
        {
            _bugButton.Enable();
            _bugButton.Rotate((endPosition - startPosition).normalized);
            _bugButton.AnchoredPosition = startPosition;
        }
    }
}