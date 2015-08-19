namespace TankFactory.Units
{
    internal class RussianTankFactory : TankFactory
    {
        public override void CreateTank()
        {
            base.tank = new Tank("T 34", 3.3, 75);
        }
    }
}
