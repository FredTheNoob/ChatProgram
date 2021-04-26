using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace WebsocketServer.Classes
{
    public class Database
    {
        public static Database instance; // Singleton

        private MongoClient Client;
        private IMongoDatabase DB;
        private IMongoCollection<User> Col;

        public Database()
        {
            Client = new MongoClient("mongodb+srv://main:CFC3dfJlU6DvXaJJ@cluster0.tkxjl.mongodb.net/test?retryWrites=true&w=majority");
            DB = Client.GetDatabase("ChatProgram");
            Col = DB.GetCollection<User>("Users");
            Console.WriteLine("FINISHED CONNECTING DB");
        }

        public void CreateNewUser(User _user)
        {
            throw new NotImplementedException();
        }

        public void SaveUser(User _user)
        {
            throw new NotImplementedException();
        }

        public User FindUser(string _name)
        {
            throw new NotImplementedException();
        }

        public bool DoesUserExist(string _name)
        {
            if (FindUser(_name) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void UpdateFriendList(string _name)
        {
            throw new NotImplementedException();
        }
    }
}
