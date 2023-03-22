using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EnterKratos.Patrol
{
    public class PatrolPointProvider : MonoBehaviour, IPatrolPointProvider
    {
        [SerializeField]
        private bool patrolPointsAreChildren;

        [SerializeField]
        private List<PatrolPoint> patrolPoints;

        public List<PatrolPoint> PatrolPoints => GetPatrolPoints();

        public bool PatrolRouteIsValid()
        {
            if (patrolPoints.Count(p => p.gameObject.activeInHierarchy) >= 2)
            {
                return true;
            }

            Debug.LogWarning("Minimum of 2 active patrol points required");
            return false;
        }

        private void Awake()
        {
            GetPatrolPoints();
        }

        private List<PatrolPoint> GetPatrolPoints()
        {
            if (patrolPointsAreChildren)
            {
                patrolPoints = new List<PatrolPoint>(GetComponentsInChildren<PatrolPoint>(true));
            }

            return patrolPoints;
        }
    }
}