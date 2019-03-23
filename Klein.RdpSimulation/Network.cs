using System;
using System.Collections.Generic;
using System.Linq;

namespace Klein.RdpSimulation
{
    public class Network
    {
        public List<Transition> Transitions { get; } = new List<Transition>();
        public List<Place> Places { get; } = new List<Place>();
        
        private readonly Random _random = new Random();

        public void Step()
        {
            var fireable = Transitions.Where(x => x.CanFire()).ToList();
            
            foreach (var transition in fireable)
            {
                while (transition.CanFire())
                {
                    transition.Fire();
                }
            }
        }

        public bool CanStep()
        {
            return Transitions.Any(x => x.CanFire());
        }

        public void Draw(int step)
        {
            Console.WriteLine($"-- step {step} --");
            foreach (var place in Places)
            {
                Console.WriteLine($"place {place.Name}: {place.Tokens}");
            }
            foreach (var transition in Transitions)
            {
                Console.WriteLine($"transition {transition.Name}: {transition.CanFire()}");                    
            }
            Console.WriteLine("----");
        }

        public static Network LoadConfig(Config config)
        {
            var net = new Network();
            
            net.Places.AddRange(config.Places.Select(x => new Place() {Name = x.Name, Tokens = x.Weights}));

            var places = net.Places.ToDictionary(p => p.Name);

            foreach (var dto in config.Transitions)
            {
                var t = new Transition() { Name = dto.Name };
                
                net.Transitions.Add(t);

                foreach (var arc in dto.Arcs)
                {
                    Place place;
                    if (!places.TryGetValue(arc.PlaceName, out place))
                    {
                        throw new InvalidOperationException($"Place with name {arc.PlaceName} not found for arc in transition {t.Name}");
                    }
                    switch (arc.Direction)
                    {
                        case ArcDirection.Incoming:
                            t.Incoming.Add(new IncomingArc(){ Place = place, Weight = arc.Weight });
                            break;
                        case ArcDirection.Outgoing:
                            t.Outgoing.Add(new OutgoingArc(){ Place = place, Weight = arc.Weight });
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(arc.Direction), "Unknown direction for arc");
                    }
                }
            }

            return net;
        }
    }
}