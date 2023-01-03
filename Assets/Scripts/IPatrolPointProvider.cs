using System.Collections.Generic;

namespace EnterKratos
{
    public interface IPatrolPointProvider
    {
        List<PatrolPoint> PatrolPoints { get; }
        bool PatrolRouteIsValid();
    }
}