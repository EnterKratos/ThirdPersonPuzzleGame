using System.Collections;
using EnterKratos.ScriptableObjects;
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
        private ThirdPersonController characterController;

        [SerializeField]
        private GameObject[] targets;

        [SerializeField]
        private Rigidbody swordCollectable;

        [SerializeField]
        private Rigidbody keyCollectable;

        [SerializeField]
        private Vector3 throwForce;

        [SerializeField]
        private float throwDelay;

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
            characterController.enabled = true;
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
            swordCollectable.gameObject.SetActive(true);
            StartCoroutine(Throw(swordCollectable, throwForce, throwDelay));
        }

        [YarnCommand("throw_key")]
        public void ThrowKey()
        {
            keyCollectable.gameObject.SetActive(true);
            StartCoroutine(Throw(keyCollectable, throwForce, throwDelay));
        }

        public void CollectableCollected(Collectable collectable)
        {
            Debug.Log(collectable.description);
        }

        public void WalkedToCorridor()
        {
            dialogueRunner.Stop();
            dialogueRunner.StartDialogue("Walked_To_Corridor");
        }

        [YarnCommand("display_run_instruction")]
        public void DisplayRunInstruction()
        {
            Debug.Log("TODO: Display run controls");
        }

        private static IEnumerator Throw(Rigidbody rigidbody, Vector3 force, float delay)
        {
            yield return new WaitForSeconds(delay);
            rigidbody.AddForce(force, ForceMode.Impulse);
        }
    }
}
