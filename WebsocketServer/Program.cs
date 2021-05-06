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
            private User user;

            protected async override void OnMessage(MessageEventArgs e)
            {
                //Sessions.Broadcast(e.Data);
                // hvis det modtagede data ikke er teks så skal resten af koden ikke køre da vores klienter kun sender text når de logger på
                if (!e.IsText) return; // TODO: File transfers here
                if (!e.Data.Contains('§')) return;

                var data = e.Data.Split('§');
                if (data[0] == "Login")
                {
                    user = await Database.GetInstance().FindUser(data[1]);

                    if(user == null)
                    {
                        Send("§Login Failed: This user doesn't exist");
                        return;
                    }

                    if (user.password == data[2])
                    {
                        userDictionary.Add(user.name, ID); 
                        Send(JsonConvert.SerializeObject(user));
                    } 
                    else
                    {
                        Send("§Login Failed: Password is incorrect");
                    }

                    // TODO: Use db to authenticate user or send back an error
                }
                else if (data[0] == "Register")
                {
                    // TODO: Register a user
                    user = await Database.GetInstance().FindUser(data[1]);

                    if (user == null)
                    {
                        User newUser = new User(data[1], data[2]);
                        Database.GetInstance().CreateNewUser(newUser);

                        userDictionary.Add(newUser.name, ID);
                        Send(JsonConvert.SerializeObject(newUser));
                    }
                    else
                    {
                        Send("§Register Failed: This user already exist. Pick another username and try again");
                    }
                }
                else if (data[0] == "Message")
                {
                    Sessions.SendTo($"{user.name}§{user.name}: {data[2]}", userDictionary[data[1]]);
                    Send($"{data[1]}§{user.name}: {data[2]}");
                }
            }
        }
    }
}
