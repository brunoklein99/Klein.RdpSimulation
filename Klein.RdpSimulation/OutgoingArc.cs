namespace Klein.RdpSimulation
{
    public class OutgoingArc : Arc
    {
        public override bool CanFire()
        {
            return true;
        }

        public override void Fire()
        {
            Place.Tokens += Weight;
        }
    }
}