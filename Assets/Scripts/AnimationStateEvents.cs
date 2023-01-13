using EnterKratos.ScriptableObjects;
using UnityEngine;

namespace EnterKratos
{
    public class AnimationStateEvents : StateMachineBehaviour
    {
        [SerializeField]
        private GameEvent animationStateEnter;

        [SerializeField]
        private GameEvent animationStateExit;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animationStateEnter.Raise();
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animationStateExit.Raise();
        }
    }
}
