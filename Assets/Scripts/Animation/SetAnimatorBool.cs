using UnityEngine;

namespace EnterKratos.Animation
{
    public class SetAnimatorBool : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private string propertyName;

        [SerializeField]
        private bool value;

        public void SetBool()
        {
            animator.SetBool(propertyName, value);
        }
    }
}