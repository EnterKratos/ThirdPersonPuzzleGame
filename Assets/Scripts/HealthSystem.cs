﻿using System.Collections;
using EnterKratos.ScriptableObjects;
using TNRD;
using UnityEngine;
using UnityEngine.Events;

namespace EnterKratos
{
    [DisallowMultipleComponent]
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField]
        private SerializableInterface<IKillable> killable;

        [SerializeField]
        private GameEventInt damagedEvent;

        [SerializeField]
        private UnityEvent<int> damagedUnityEvent;

        [SerializeField]
        private GameEventInt healedEvent;

        [SerializeField]
        private UnityEvent<int> healedUnityEvent;

        [SerializeField]
        private GameEvent diedEvent;

        [SerializeField]
        private UnityEvent diedUnityEvent;

        [SerializeField]
        private bool invulnerable;

        public bool Dead => _health <= 0;

        private bool _dead;
        private int _health;
        private bool _coolingDown;

        private void OnEnable()
        {
            _health = killable.Value.MaxHealth;
        }

        public void Attack(int amount)
        {
            if (_coolingDown || _dead || invulnerable)
            {
                return;
            }

            _health = ClampHealth(_health - amount);

            if (damagedEvent)
            {
                damagedEvent.Raise(amount);
            }
            damagedUnityEvent.Invoke(amount);
            _coolingDown = true;
            StartCoroutine(CooldownTimer());

            if (!Dead)
            {
                return;
            }

            if (diedEvent)
            {
                diedEvent.Raise();
            }
            diedUnityEvent.Invoke();
            _dead = true;
        }

        public void Heal(int amount)
        {
            if (Dead)
            {
                return;
            }

            _health = ClampHealth(_health + amount);

            if (healedEvent)
            {
                healedEvent.Raise(amount);
            }
            healedUnityEvent.Invoke(amount);
        }

        private int ClampHealth(int value)
        {
            return Mathf.Clamp(value, 0, killable.Value.MaxHealth);
        }

        private IEnumerator CooldownTimer()
        {
            yield return new WaitForSeconds(killable.Value.DamageCooldown);
            _coolingDown = false;
        }
    }
}