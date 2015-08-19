namespace TankFactory.Units
{
    internal class Tank
    {
        public Tank(string model, double speed, int attackDamage)
        {
            this.Model = model;
            this.Speed = speed;
            this.AttackDamage = attackDamage;
        }

        public string Model { get; set; }

        public double Speed { get; set; }

        public int AttackDamage { get; set; }
    }
}
