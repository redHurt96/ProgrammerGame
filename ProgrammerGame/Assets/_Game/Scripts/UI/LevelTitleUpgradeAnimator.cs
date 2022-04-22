using _Game.Common;
using UnityEngine;

namespace _Game.UI
{
    [RequireComponent(typeof(Animator))]
    public class LevelTitleUpgradeAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private static readonly int _bounceTriggerNameHash = Animator.StringToHash("Bounce");

        private void Start() => 
            _globalEvents.LevelChanged += EnableAnimation;

        private void OnDestroy() => 
            _globalEvents.LevelChanged -= EnableAnimation;

        private void EnableAnimation() => 
            _animator.SetTrigger(_bounceTriggerNameHash);
    }
}