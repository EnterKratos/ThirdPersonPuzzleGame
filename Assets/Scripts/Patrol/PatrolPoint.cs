using EnterKratos.Extensions;
using UnityEngine;

namespace EnterKratos.Patrol
{
    [RequireComponent(typeof(Collider))]
    public class PatrolPoint : MonoBehaviour
    {
        private void Awake()
        {
            GetComponents<Collider>().AssertTrigger();
        }

        private void OnTriggerEnter(Collider other)
        {
            var patrol = other.GetComponent<IPatrol>();
            if (patrol == null || this != patrol.TargetPatrolPoint)
            {
                return;
            }

            patrol.Arrived();
        }
    }
}