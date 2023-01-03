namespace EnterKratos
{
    public interface IPatrol
    {
        PatrolPoint TargetPatrolPoint { get; }
        void Arrived();
    }
}