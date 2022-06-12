using _Game.Common;
using UnityEngine;

namespace _Game.UI.LevelPanel
{
    [RequireComponent(typeof(Animator))]
    public class LevelTitleUpgradeAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int _bounceTriggerNameHash = Animator.StringToHash("Bounce");

        private void Start() => 
            EventsMediator.Instance.LevelChanged += EnableAnimation;

        private void OnDestroy() => 
            EventsMediator.Instance.LevelChanged -= EnableAnimation;

        private void EnableAnimation() => 
            _animator.SetTrigger(_bounceTriggerNameHash);
    }
}