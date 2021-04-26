using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsocketServer.Classes
{
    public class User
    {
        public string name { get; set; }
        public int id { get; set; }
        public DateTime createdAt;
        public List<User> friendsList;

        public User(string _name)
        {
            if (Database.instance.DoesUserExist(_name) == true)
            {
                // ERROR
            } 
            else
            {
                // MAKE NEW USER
                _name = name;
            }
        }

        public void SendFriendRequest(string _name)
        {

        }

        public void AcceptFriendRequest(string _name)
        {
            
            User _user = Database.instance.FindUser(_name);

            _user.friendsList.Add(this);
            friendsList.Add(_user);

            // Save in DB
            Database.instance.SaveUser(this);
            Database.instance.SaveUser(_user);
        }
    }
}
