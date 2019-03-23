namespace Klein.RdpSimulation
{
    public class IncomingArc : Arc
    {
        public override bool CanFire()
        {
            return Place.Tokens >= Weight;
        }

        public override void Fire()
        {
            Place.Tokens -= Weight;
        }
    }
}