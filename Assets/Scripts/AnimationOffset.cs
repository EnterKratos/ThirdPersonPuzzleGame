using UnityEngine;

namespace EnterKratos
{
    public class AnimationOffset : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        [SerializeField, Range(0, 1)]
        private float offset;

        private readonly int _offsetHash = Animator.StringToHash("Offset");

        private void Start()
        {
            animator.SetFloat(_offsetHash, offset);
        }
    }
}
