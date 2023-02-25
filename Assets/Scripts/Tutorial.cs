using StarterAssets;
using UnityEngine;
using Yarn.Unity;

namespace EnterKratos
{
    public class Tutorial : MonoBehaviour
    {
        [SerializeField]
        private DialogueRunner dialogueRunner;
        
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private ThirdPersonController controller;

        [SerializeField]
        private Rigidbody swordCollectable;
        
        [SerializeField]
        private Vector3 swordThrowForce;

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

        public void WalkedToTrainingDummy()
        {
            dialogueRunner.StartDialogue("Walked_To_Training_Dummy");
        }

        [YarnCommand("throw_sword")]
        public void ThrowSword()
        {
            swordCollectable.AddForce(swordThrowForce, ForceMode.Impulse);
        }
    }
}
