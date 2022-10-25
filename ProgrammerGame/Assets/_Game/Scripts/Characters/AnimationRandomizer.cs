using UnityEngine;
using Random = UnityEngine.Random;

namespace _Game.Characters
{
    public class AnimationRandomizer : MonoBehaviour
    {
        private static readonly int _idleCycleOffset = Animator.StringToHash("IdleCycleOffset");
        
        [SerializeField] private Animator _animator;

        private void Start() => 
            _animator.SetFloat(_idleCycleOffset, Random.value);
    }
}