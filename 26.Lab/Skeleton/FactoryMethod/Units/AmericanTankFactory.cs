namespace TankFactory.Units
{
    internal class AmericanTankFactory : TankFactory
    {
        public override void CreateTank()
        {
            base.tank = new Tank("M1 Abrams", 5.4, 120);
        }
    }
}
