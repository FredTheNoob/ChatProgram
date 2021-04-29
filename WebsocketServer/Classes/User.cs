using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketServer.Classes
{
    [MongoDB.Bson.Serialization.Attributes.BsonIgnoreExtraElements]
    public class User
    {
        public string name { get; set; }
        public string password { get; set; }
        public DateTime createdAt { get; set; }
        public List<string> friendsList { get; set; }
        public List<string> pendingFriendsList { get; set; }
        public List<string> sentPendingFriendsList { get; set; }

        public User(string _name, string _password)
        {
            name = _name;
            password = _password;
            createdAt = DateTime.Now;
            friendsList = new List<string>();
            pendingFriendsList = new List<string>();
            sentPendingFriendsList = new List<string>();
        }

        public void Create(User _user)
        {
            Database.GetInstance().CreateNewUser(_user);
        }

        public async Task SendFriendRequest(User _user)
        {
            await Database.GetInstance().AddPendingFriendRequest(_user, this);
        }

        public async Task RemoveFriendRequest(User _user)
        {
            await Database.GetInstance().RemovePendingFriendRequest(this, _user);
        }

        public async Task AcceptFriendRequest(User _otherUser)
        {
            await Database.GetInstance().AddFriend(this, _otherUser);
        }

        public async void RemoveFriend(string _name)
        {
            User _user = await Database.GetInstance().FindUser(_name);

            Database.GetInstance().RemoveFriend(this, _user);
        }
    }
}
