using Akka.Actor;
using AR.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR.Server
{

    


    public class GreetingActor : ReceiveActor
    {
        public GreetingActor()
        {
            // Tell the actor to respond
            // to the Greet message
            Receive<Greet>(greet =>
               Console.WriteLine("Hello {0}", greet.Who));
        }
    }

}
