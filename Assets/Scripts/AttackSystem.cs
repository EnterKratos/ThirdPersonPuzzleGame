using System.Collections;
using UnityEngine;

namespace EnterKratos
{
    [DisallowMultipleComponent]
    public class AttackSystem : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;

        private bool _coolingDown;

        public bool Attack()
        {
            if (_coolingDown || weapon == null || !weapon.gameObject.activeSelf)
            {
                return false;
            }

            _coolingDown = true;
            StartCoroutine(CooldownTimer());

            return true;
        }

        private IEnumerator CooldownTimer()
        {
            yield return new WaitForSeconds(weapon.AttackCooldown);
            _coolingDown = false;
        }
    }
}