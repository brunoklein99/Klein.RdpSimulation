using System;
using System.Collections.Generic;
using System.Linq;

namespace Klein.RdpSimulation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new InvalidOperationException("Args not provided");
            }
            
            var config = Config.LoadFromFile(args[0]);

            var net = Network.LoadConfig(config);

            var step = 0;
            while (true)
            {
                net.Draw(step++);
                if (net.CanStep())
                {
                    net.Step();
                }
                else
                {
                    break;
                }
            }
        }
    }
}