using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using WebsocketServer.Classes;

namespace WebsocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make MongoDB instance
            Database.GetInstance();

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
                Console.WriteLine($"Is Binary: {e.IsBinary} | Is Text {e.IsText} | Is Ping {e.IsPing}");
                Sessions.Broadcast(e.Data);
                
            }
        }

        public class Auth : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                // hvis det modtagede data ikke er teks så skal resten af koden ikke køre da vores klienter kun sender text når de logger på
                if (!e.IsText) return;

                var data = e.Data.Split('§');
                
                if (data[0] == "Login")
                {
                    // TODO: Use db to authenticate user or send back an error
                }
                else if (data[0] == "Register")
                {
                    // TODO: Register a user
                }
            }
        }
    }
}
