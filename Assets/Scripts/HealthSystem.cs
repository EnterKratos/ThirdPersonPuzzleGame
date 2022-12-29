﻿using System.Collections;
using EnterKratos.ScriptableObjects;
using TNRD;
using UnityEngine;

namespace EnterKratos
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField]
        private SerializableInterface<IKillable> killable;

        [SerializeField]
        private GameEventInt damagedEvent;

        [SerializeField]
        private GameEvent diedEvent;

        private int _health;
        private bool _coolingDown;

        private void OnEnable()
        {
            _health = killable.Value.MaxHealth;
        }

        public void Attack(int amount)
        {
            if (_coolingDown)
            {
                return;
            }

            _health -= amount;
            damagedEvent.Raise(amount);
            _coolingDown = true;
            StartCoroutine(CooldownTimer());

            if (_health <= 0)
            {
                diedEvent.Raise();
            }
        }

        private IEnumerator CooldownTimer()
        {
            yield return new WaitForSeconds(killable.Value.DamageCooldown);
            _coolingDown = false;
        }
    }
}