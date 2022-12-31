using System.Collections;
using UnityEngine;

namespace EnterKratos
{
    public class Boat : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private float moveDelay;

        private bool _gateLocked = true;
        private int _departHash;

        public void GateUnlocked()
        {
            _gateLocked = false;
        }

        public void MoveBoat()
        {
            if (_gateLocked)
            {
                Debug.Log("Gate is locked");
            }
            else
            {
                StartCoroutine(MoveBoatCoroutine());
            }
        }

        private void Awake()
        {
            _departHash = Animator.StringToHash("Depart");
        }

        private IEnumerator MoveBoatCoroutine()
        {
            yield return new WaitForSeconds(moveDelay);

            animator.SetTrigger(_departHash);
        }
    }
}
