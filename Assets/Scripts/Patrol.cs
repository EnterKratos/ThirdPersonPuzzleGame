using UnityEngine;
using UnityEngine.AI;

namespace EnterKratos
{
    public class Patrol : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent navMeshAgent;

        [SerializeField]
        private float tolerance = 0;

        [SerializeField]
        private Transform[] patrolPoints;

        private int _patrolPointIndex = 0;

        private void Start()
        {
            GoToPoint();
        }

        private void Update()
        {
            var distance = Vector3.Distance(transform.position, patrolPoints[_patrolPointIndex].position);

            if (distance > tolerance)
            {
                return;
            }

            if (_patrolPointIndex == patrolPoints.Length - 1)
            {
                _patrolPointIndex = 0;
            }
            else
            {
                _patrolPointIndex++;
            }

            GoToPoint();
        }

        private void GoToPoint()
        {
            navMeshAgent.destination = patrolPoints[_patrolPointIndex].position;
        }
    }
}
