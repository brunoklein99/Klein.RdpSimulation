namespace Klein.RdpSimulation
{
    public class Place
    {
        public int Tokens { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}={Tokens}";
        }
    }
}