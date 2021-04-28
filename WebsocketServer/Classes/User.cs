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
        public List<User> friendsList { get; set; }
        public List<User> pendingFriendsList { get; set; }

        public User(string _name, string _password)
        {
            name = _name;
            password = _password;
            createdAt = DateTime.Now;
            friendsList = new List<User>();
            pendingFriendsList = new List<User>();
        }

        public void Create(User _user)
        {
            Database.GetInstance().CreateNewUser(_user);
        }

        public async void SendFriendRequest(string _name)
        {
            User _user = await Database.GetInstance().FindUser(_name);

            Database.GetInstance().AddPendingFriendRequest(_user);
        }

        public async void AcceptFriendRequest(string _name)
        {
            User _user = await Database.GetInstance().FindUser(_name);

            Database.GetInstance().AddFriend(this);
            Database.GetInstance().AddFriend(_user);
        }

        public async void RemoveFriend(string _name)
        {
            User _user = await Database.GetInstance().FindUser(_name);

            Database.GetInstance().RemoveFriend(this, _user);
        }
    }
}
