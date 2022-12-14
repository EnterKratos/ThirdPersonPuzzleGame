using UnityEngine;
using UnityEngine.AI;

namespace EnterKratos
{
    public class NavMeshAgentFollow : MonoBehaviour
    {
        [SerializeField]
        private NavMeshAgent navMeshAgent;

        [SerializeField]
        private Transform target;

        private void Update()
        {
            navMeshAgent.destination = target.position;
        }
    }
}
