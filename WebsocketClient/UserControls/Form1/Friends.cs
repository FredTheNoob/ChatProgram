using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using WebsocketServer.Classes;
using ChatProgram.UserControls.Friends;
using ChatProgram;

namespace ChatProgram.UserControls.Form1
{
    public partial class Friends : MetroUserControl
    {
        private ChatProgram.Form1 main;
        private User signedInUser;
        public Friends()
        {
            InitializeComponent();
        }

        public void Setup(ChatProgram.Form1 _main, User _signedInUser)
        {
            main = _main;
            signedInUser = _signedInUser;

            CheckForFriendRequests();
        } 

        private async void btnFindUser_Click(object sender, EventArgs e)
        {
            if (txtFindUser.Text == "") UpdateStatusLabel("Username cannot be empty", Color.Red); 

            User user = await Database.GetInstance().FindUser(txtFindUser.Text);
            
            if (user == null)
            {
                UpdateStatusLabel("That user doesn't exist", Color.Red);
                return;
            }
            
            if (signedInUser.name == user.name)
            {
                UpdateStatusLabel("You cannot send yourself a friend request", Color.Red);
                return;
            }

            if (signedInUser.friendsList.Contains(user.name))
            {
                UpdateStatusLabel($"You are already friends with {user.name}", Color.Red);
                return;
            }

            if (pnlPending.Controls.ContainsKey(txtFindUser.Text) == true)
            {
                UpdateStatusLabel("You have already sent a friend request to this user", Color.Red);
                return;
            }

            await signedInUser.SendFriendRequest(user);

            PendingCard card = new PendingCard(signedInUser, user);
            card.Removed += OnCardRemoved;

            card.Dock = DockStyle.Top;
            pnlPending.Controls.Add(card);

            UpdateStatusLabel($"Successfully sent a friend request to {user.name}", Color.Green);
        }

        private async void CheckForFriendRequests()
        {
            if (signedInUser.pendingFriendsList.Count > 0)
            {
                foreach (string otherUsername in signedInUser.pendingFriendsList)
                {
                    User otherUser = await Database.GetInstance().FindUser(otherUsername);

                    IncomingCard card = new IncomingCard(signedInUser, otherUser);
                    card.Finished += OnFinished;

                    card.Dock = DockStyle.Top;
                    pnlIncoming.Controls.Add(card);
                }
            }
        }

        private void OnCardRemoved(PendingCard _card) => pnlPending.Controls.RemoveByKey(_card.Name);

        private void OnFinished(IncomingCard _card)
        {
            pnlIncoming.Controls.RemoveByKey(_card.Name);
            main.LoadFriends();
        }

        private void UpdateStatusLabel(string _text, Color _color)
        {
            lblStatus.ForeColor = _color;
            lblStatus.Text = _text;
            lblStatus.Visible = true;
        }
    }
}
