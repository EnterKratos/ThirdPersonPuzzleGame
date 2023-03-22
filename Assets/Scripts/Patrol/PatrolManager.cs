using System;

namespace EnterKratos.Patrol
{
    public class PatrolManager
    {
        private readonly IPatrolPointProvider _patrolPointProvider;
        private int _current = -1;

        public PatrolManager(IPatrolPointProvider patrolPointProvider)
        {
            _patrolPointProvider = patrolPointProvider;
        }

        public PatrolPoint Next()
        {
            _current = GetNextPatrolPointRecursive(_current);
            return _patrolPointProvider.PatrolPoints[_current];
        }

        private int GetNextPatrolPointRecursive(int currentPatrolPoint, int accumulator = 0)
        {
            if (accumulator > _patrolPointProvider.PatrolPoints.Count)
            {
                throw new InvalidOperationException("All patrol points are disabled");
            }

            if (currentPatrolPoint == _patrolPointProvider.PatrolPoints.Count - 1)
            {
                return GetNextPatrolPointRecursive(-1, ++accumulator);
            }

            var next = currentPatrolPoint + 1;

            return _patrolPointProvider.PatrolPoints[next].gameObject.activeInHierarchy
                ? next
                : GetNextPatrolPointRecursive(next, ++accumulator);
        }
    }
}