//Aqui listamos todas las librerias/paquetes que vamos a usar
using System;
using Grpc.Core;
using Google;
using RPCDemoClient;
using System.Diagnostics;
using System.Threading;

namespace RPC_Client
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Generamos el canal con la dirección del servidor y luego creamos el cliente que se conecta a dicho canal
            var channel = new Grpc.Core.Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new GRPC.GRPCClient(channel);
            while (true)
            {
                //Generamos un ciclo donde le hacemos un request al server constantemente
                var reply = client.GetCoordinates(new Google.Protobuf.WellKnownTypes.Empty());
                //Imprimimos la respuesta del servidor(dos valores) en la terminal y esperamos 500 ms
                Console.WriteLine("Coordinates: " + reply.X + "," + reply.Y);
                Thread.Sleep(500);
            }
        }
    }
}
