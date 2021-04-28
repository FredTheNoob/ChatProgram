using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WebsocketServer.Classes
{
    public class Database
    {
        private static Database instance;

        private MongoClient Client;
        private IMongoDatabase DB;
        private IMongoCollection<User> Col;

        public static Database GetInstance()
        {
            if (instance == null)
            {
                instance = new Database();
            }
            return instance;
        }

        private Database()
        {
            Client = new MongoClient("mongodb+srv://main:CFC3dfJlU6DvXaJJ@cluster0.tkxjl.mongodb.net/test?retryWrites=true&w=majority");
            DB = Client.GetDatabase("ChatProgram");
            Col = DB.GetCollection<User>("Users");
            Console.WriteLine("FINISHED CONNECTING DB");
        }

        public void CreateNewUser(User _user)
        {
            try
            {
                MessageBox.Show($"Creating user ${_user.name}");
                Col.InsertOne(_user);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error while setting up db entry for user ${_user.name}: {e.Message}");
            }
        }

        public async Task<User> FindUser(string _name)
        {
            var res = await Col.FindAsync<User>(x => x.name == _name);
            return res.FirstOrDefault();
        }

        public async Task<bool> DoesUserExist(string _name)
        {
            User searchedUser = await FindUser(_name);
            if (searchedUser == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async void AddFriend(User _user)
        {
            User searchedUser = await FindUser(_user.name);
            List<User> friends = searchedUser.friendsList;

            if (friends == null) friends = new List<User>();
            friends.Add(_user);

            var update = Builders<User>.Update.Set(x => x.friendsList, friends);
            await Col.UpdateOneAsync(x => x.name == _user.name, update);
        }

        public async void AddPendingFriendRequest(User _user)
        {
            User searchedUser = await FindUser(_user.name);
            List<User> friends = searchedUser.pendingFriendsList;

            if (friends == null) friends = new List<User>();
            friends.Add(_user);

            var update = Builders<User>.Update.Set(x => x.friendsList, friends);
            await Col.UpdateOneAsync(x => x.name == _user.name, update);
        }

        public async void RemoveFriend(User _user, User _userRemoved)
        {
            User searchedUser = await FindUser(_user.name);
            User searchedUserRemoved = await FindUser(_userRemoved.name);

            List<User> friends = searchedUser.friendsList;
            List<User> friendsRemoved = searchedUserRemoved.friendsList;

            friends.Remove(friends.Find(x => x.name == _user.name));
            friendsRemoved.Remove(friendsRemoved.Find(x => x.name == _userRemoved.name));

            var update = Builders<User>.Update.Set(x => x.friendsList, friends);
            var updateRemoved = Builders<User>.Update.Set(x => x.friendsList, friendsRemoved);

            await Col.UpdateOneAsync(x => x.name == _user.name, update);
            await Col.UpdateOneAsync(x => x.name == _userRemoved.name, updateRemoved);
        }
    }
}
