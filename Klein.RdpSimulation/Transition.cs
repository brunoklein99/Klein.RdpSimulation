using System.Collections.Generic;
using Newtonsoft.Json;

namespace Klein.RdpSimulation
{
    public class Transition
    {
        public List<IncomingArc> Incoming { get; } = new List<IncomingArc>();
        public List<OutgoingArc> Outgoing { get; } = new List<OutgoingArc>();

        public string Name { get; set; }
        
        public bool CanFire()
        {
            var incoming = Incoming.TrueForAll(a => a.CanFire());
            var outgoing = Outgoing.TrueForAll(a => a.CanFire());
            return incoming && outgoing;
        }

        public void Fire()
        {
            foreach (var incoming in Incoming)
            {
                incoming.Fire();
            }

            foreach (var outgoing in Outgoing)
            {
                outgoing.Fire();
            }
        }
    }
}