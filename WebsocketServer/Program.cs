using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebsocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            WebSocketServer wss = new WebSocketServer(6969);
            wss.AddWebSocketService<Chat>("/Chat");
            wss.Start();
            Console.WriteLine("Listening for messages...");
            Console.ReadKey(true);
        }

        public class Chat : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                Sessions.Broadcast(e.Data);
            }
        }
    }
}
