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
                //MessageBox.Show($"Creating user {_user.name}");
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

        public async Task AddFriend(User _userThatAccepted ,User _user)
        {
            List<string> friends = _user.friendsList;
            List<string> friendsAccepted = _userThatAccepted.friendsList;

            friends.Add(_userThatAccepted.name);
            friendsAccepted.Add(_user.name);

            var update = Builders<User>.Update.Set(x => x.friendsList, friends);
            await Col.UpdateOneAsync(x => x.name == _user.name, update);

            var updateAccepted = Builders<User>.Update.Set(x => x.friendsList, friendsAccepted);
            await Col.UpdateOneAsync(x => x.name == _userThatAccepted.name, updateAccepted);
        }

        public async Task AddPendingFriendRequest(User _user, User _thisUser)
        {
            List<string> friends = _user.pendingFriendsList;

            friends.Add(_thisUser.name);
            _thisUser.sentPendingFriendsList.Add(_user.name);            

            var update = Builders<User>.Update.Set(x => x.pendingFriendsList, friends);
            await Col.UpdateOneAsync(x => x.name == _user.name, update);

            var updateSelf = Builders<User>.Update.Set(x => x.sentPendingFriendsList, _thisUser.sentPendingFriendsList);
            await Col.UpdateOneAsync(x => x.name == _thisUser.name, updateSelf);
        }

        public async Task RemovePendingFriendRequest(User _userRemoved, User _user)
        {
            List<string> friends = _user.pendingFriendsList;
            List<string> sentFriends = _userRemoved.sentPendingFriendsList;

            friends.Remove(friends.Find(x => x == _userRemoved.name));
            sentFriends.Remove(sentFriends.Find(x => x == _user.name));

            var update = Builders<User>.Update.Set(x => x.pendingFriendsList, friends);
            await Col.UpdateOneAsync(x => x.name == _user.name, update);

            var updateSent = Builders<User>.Update.Set(x => x.sentPendingFriendsList, sentFriends);
            await Col.UpdateOneAsync(x => x.name == _userRemoved.name, updateSent);
        }

        public async void RemoveFriend(User _user, User _userRemoved)
        {
            User searchedUser = await FindUser(_user.name);
            User searchedUserRemoved = await FindUser(_userRemoved.name);

            List<string> friends = searchedUser.friendsList;
            List<string> friendsRemoved = searchedUserRemoved.friendsList;

            friends.Remove(friends.Find(x => x == _user.name));
            friendsRemoved.Remove(friendsRemoved.Find(x => x == _userRemoved.name));

            var update = Builders<User>.Update.Set(x => x.friendsList, friends);
            var updateRemoved = Builders<User>.Update.Set(x => x.friendsList, friendsRemoved);

            await Col.UpdateOneAsync(x => x.name == _user.name, update);
            await Col.UpdateOneAsync(x => x.name == _userRemoved.name, updateRemoved);
        }
    }
}
