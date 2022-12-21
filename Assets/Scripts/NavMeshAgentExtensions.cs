using UnityEngine;
using UnityEngine.AI;

namespace EnterKratos
{
    public static class NavMeshAgentExtensions
    {
        public static void GoToPoint(this NavMeshAgent navMeshAgent, Vector3 point)
        {
            var result = navMeshAgent.SetDestination(point);
            if (!result)
            {
                Debug.LogWarning($"Failed to set NavMeshAgent({navMeshAgent.GetInstanceID()}) destination");
            }
        }
    }
}