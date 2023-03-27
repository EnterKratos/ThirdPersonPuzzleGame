using EnterKratos.StateMachines;
using UnityEngine;
using Yarn.Unity;

namespace EnterKratos.Tutorials
{
    public class CombatTutorial : TutorialBase
    {
        [SerializeField]
        private GameObject swordTarget;

        [SerializeField]
        private Collider sword;

        [SerializeField]
        private EnemyStateMachine skeleton;

        [YarnCommand("set_sword_target_active")]
        public void SetSwordTargetActiveState(bool active)
        {
            swordTarget.SetActive(active);
            sword.enabled = active;
        }

        [YarnCommand("release_skeleton")]
        public void ReleaseSkeleton()
        {
            skeleton.enabled = true;
        }
    }
}