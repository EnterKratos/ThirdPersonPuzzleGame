using UnityEngine;

namespace EnterKratos.StateMachineBehaviours
{
    public class ToggleBool : StateMachineBehaviour
    {
        [SerializeField]
        private string parameter;

        private int _parameterHash;

        private void Awake()
        {
            _parameterHash = Animator.StringToHash(parameter);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool(_parameterHash, !animator.GetBool(_parameterHash));
        }
    }
}
