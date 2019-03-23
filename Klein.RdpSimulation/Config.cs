using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Klein.RdpSimulation
{
    public class Config
    {
        public List<PlaceDto> Places { get; set; }
        public List<TransitionDto> Transitions { get; set; }

        public static Config LoadFromFile(string filename)
        {
            var content = File.ReadAllText(filename);

            return JsonConvert.DeserializeObject<Config>(content);
        }
    }

    public class TransitionDto
    {
        public string Name { get; set; }
        public List<ArcDto> Arcs { get; set; }
    }

    public class PlaceDto
    {
        public string Name { get; set; }
        public int Weights { get; set; }
    }

    public enum ArcDirection
    {
        Incoming,
        Outgoing
    }
    
    public class ArcDto
    {
        public ArcDirection Direction { get; set; }
        public int Weight { get; set; }
        public string PlaceName { get; set; }
    }
}