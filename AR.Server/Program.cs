using Akka.Actor;
using Akka.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AR.Server
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
                                            port = 8080
                                            hostname = localhost
                                        }
                                    }
                                }
                                ");

            using (ActorSystem system = ActorSystem.Create("MyServer", config))
            {
                system.ActorOf<GreetingActor>("greeter");
                Console.ReadKey();
            }
        }
    }
}
