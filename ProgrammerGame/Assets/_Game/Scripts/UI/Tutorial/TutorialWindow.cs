using System.Collections;
using _Game.Configs;
using UnityEngine;

namespace _Game.UI.Tutorial
{
    public class TutorialWindow : MonoBehaviour
    {
        private bool _isDestroyed;
        private bool _canClose;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(TutorialSettings.Instance.WindowNonInteractableTime);

            _canClose = true;

            yield return new WaitForSeconds(TutorialSettings.Instance.WindowLifeTime);

            Destroy();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && _canClose)
                Destroy();
        }

        public void Enable() => 
            gameObject.SetActive(true);

        private void Destroy()
        {
            if (_isDestroyed)
                return;

            _isDestroyed = true;

            Destroy(gameObject);
        }
    }
}