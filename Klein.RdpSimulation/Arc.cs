namespace Klein.RdpSimulation
{
    public abstract class Arc
    {
        public Place Place { get; set; }
        public int Weight { get; set; }
        
        public abstract bool CanFire();
        public abstract void Fire();
    }
}