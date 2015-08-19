namespace TankFactory.Units
{
    internal abstract class TankFactory
    {
        protected Tank tank;

        public abstract void CreateTank();

        public override string ToString()
        {
            return string.Format(
                "-Tank\n...Model: {0}\n...Speed: {1:F2}\n...Damage: {2}",
                this.tank.Model,
                this.tank.Speed,
                this.tank.AttackDamage);
        }
    }
}
