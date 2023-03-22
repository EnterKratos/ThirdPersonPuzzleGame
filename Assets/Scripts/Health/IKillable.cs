namespace EnterKratos.Health
{
    public interface IKillable
    {
        public int MaxHealth { get; }
        public float DamageCooldown { get; }
    }
}