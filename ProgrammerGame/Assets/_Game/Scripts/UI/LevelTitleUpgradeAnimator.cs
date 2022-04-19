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
            GlobalEvents.Instance.LevelChanged += EnableAnimation;

        private void OnDestroy() => 
            GlobalEvents.Instance.LevelChanged -= EnableAnimation;

        private void EnableAnimation() => 
            _animator.SetTrigger(_bounceTriggerNameHash);
    }
}