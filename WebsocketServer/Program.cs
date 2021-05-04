using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Server;
using WebsocketServer.Classes;
using Newtonsoft.Json;

namespace WebsocketServer
{
    class Program
    {
        private static Dictionary<string, string> userDictionary;

        static void Main(string[] args)
        {
            // Make MongoDB instance
            Database.GetInstance();

            WebSocketServer wss = new WebSocketServer(6969);
            wss.AddWebSocketService<Chat>("/Chat");
            wss.Start();
            Console.WriteLine("Listening for messages...");

            userDictionary = new Dictionary<string, string>();

            Console.ReadKey(true);
        }

        public class Chat : WebSocketBehavior
        {

            protected async override void OnMessage(MessageEventArgs e)
            {
                Console.WriteLine($"Is Binary: {e.IsBinary} | Is Text {e.IsText} | Is Ping {e.IsPing}");
                //Sessions.Broadcast(e.Data);
                // hvis det modtagede data ikke er teks så skal resten af koden ikke køre da vores klienter kun sender text når de logger på
                
                //if (!e.IsText) return; // TODO: File transfers here
                //if (!e.Data.Contains('§')) return;

                var data = e.Data.Split('§');
                
                

                Console.WriteLine("HELLOOOOOOOOO");

                if (data[0] == "Login")
                {


                    var user = await Database.GetInstance().FindUser(data[1]);

                    if(user == null) return;

                    if (user.password == data[2])
                    {
                        userDictionary.Add(user.name, ID);
                        Send(JsonConvert.SerializeObject(user));

                    } 

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
