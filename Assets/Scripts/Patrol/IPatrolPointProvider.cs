using System.Collections.Generic;

namespace EnterKratos.Patrol
{
    public interface IPatrolPointProvider
    {
        List<PatrolPoint> PatrolPoints { get; }
        bool PatrolRouteIsValid();
    }
}