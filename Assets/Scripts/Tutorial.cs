using StarterAssets;
using UnityEngine;
using Yarn.Unity;

namespace EnterKratos
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private ThirdPersonController controller;

        private int _standUpHash;

        private void Awake()
        {
            _standUpHash = Animator.StringToHash("StandUp");
        }

        [YarnCommand("stand_up")]
        public void StandUp()
        {
            animator.SetTrigger(_standUpHash);
        }

        [YarnCommand("unlock_movement")]
        public void UnlockMovement()
        {
            controller.enabled = true;
        }
    }
}
