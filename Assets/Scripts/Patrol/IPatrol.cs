namespace EnterKratos.Patrol
{
    public interface IPatrol
    {
        PatrolPoint TargetPatrolPoint { get; }
        void Arrived();
    }
}