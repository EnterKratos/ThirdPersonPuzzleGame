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
        private GameObject[] targets;

        [SerializeField]
        private Rigidbody swordCollectable;
        
        [SerializeField]
        private Vector3 swordThrowForce;

        private int _standUpHash;
        private int _currentTarget;

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

        [YarnCommand("set_target")]
        public void SetTarget(int targetIndex)
        {
            _currentTarget = targetIndex;
            targets[targetIndex].SetActive(true);
        }

        public void WalkedToTarget()
        {
            targets[_currentTarget].SetActive(false);
            dialogueRunner.Stop();
            dialogueRunner.StartDialogue("Walked_To_Target");
        }

        [YarnCommand("throw_sword")]
        public void ThrowSword()
        {
            swordCollectable.AddForce(swordThrowForce, ForceMode.Impulse);
        }
    }
}
