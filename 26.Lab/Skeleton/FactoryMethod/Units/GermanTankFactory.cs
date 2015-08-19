namespace TankFactory.Units
{
    internal class GermanTankFactory : TankFactory
    {
        public override void CreateTank()
        {
            base.tank = new Tank("Tiger", 4.5, 120);
        }
    }
}
