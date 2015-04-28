using Akka.Actor;
using Akka.Configuration;
using AR.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR.Client2
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(@"
                akka {
                    actor {
                        provider = ""Akka.Remote.RemoteActorRefProvider, Akka.Remote""
                    }
                    remote {
                        helios.tcp {
                            port = 8090
                            hostname = localhost
                        }
                    }
                }
                ");

            using (var system = ActorSystem.Create("MyClient", config))
            {
                //get a reference to the remote actor
                var greeter = system
                    .ActorSelection("akka.tcp://MyServer@localhost:8080/user/greeter");
                //send a message to the remote actor
                greeter.Tell(new Greet("Dustyn"));


                string s = Console.ReadLine();

                while ( s != "quit")
                {
                    greeter.Tell(s);
                    s = Console.ReadLine();
                }
                
            }

        }
    }
}
