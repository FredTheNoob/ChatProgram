using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using MetroFramework.Forms;
using MetroFramework.Controls;
using WebsocketServer.Classes;
using ChatProgram.UserControls.Form1;

namespace ChatProgram
{
    public partial class Form1 : MetroForm
    {
        WebSocket ws;

        private User signedInUser;

        private Dictionary<string, Chat> chatUserControls = new Dictionary<string, Chat>();

        public Form1(User _user, WebSocket _ws)
        {
            ws = _ws;
            signedInUser = _user;

            InitializeComponent();

            // USER CONTROLS
            usrFriends.Setup(this, signedInUser);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActiveControl = btnFriends;
            lblUsername.Text = signedInUser.name;
            LoadFriends();
            ws.OnMessage += OnMessage;
        }


        public void LoadFriends()
        {
            pnlFriends.Controls.Clear();

            if (signedInUser.friendsList.Count > 0)
            {
                foreach (string friendName in signedInUser.friendsList)
                {
                    MetroButton btnFriend = new MetroButton();

                    btnFriend.Text = friendName;
                    btnFriend.Dock = DockStyle.Top;
                    btnFriend.Size = new Size(187, 38);
                    btnFriend.Theme = MetroFramework.MetroThemeStyle.Dark;
                    btnFriend.Click += (sender, e) => btnFriendClicked(sender, e, btnFriend.Text);

                    Chat userChat = new Chat(btnFriend.Text, ws);
                    userChat.Location = new Point(205, 35);
                    userChat.Hide();

                    Controls.Add(userChat);
                    chatUserControls.Add(btnFriend.Text, userChat);

                    pnlFriends.Controls.Add(btnFriend);
                }
            }
        }

        private void btnFriendClicked(object sender, EventArgs e, string name)
        {
            usrFriends.Hide();

            HideAllChatUserControls();
            chatUserControls[name].Show();
        }

        private void btnFriends_Click(object sender, EventArgs e)
        {
            usrFriends.Show();
        }

        private void HideAllChatUserControls()
        {
            foreach (Chat control in chatUserControls.Values)
            {
                control.Hide();
            }
        }

        private void OnMessage(object sender, MessageEventArgs e)
        {
            // Visibility
            this.Invoke((Action)delegate
            {
                var data = e.Data.Split('§');
                chatUserControls[data[0]].AddMessage(data[1]);
                new SoundPlayer(@"c:\Windows\Media\chimes.wav").Play();
            });
        }
    }
}
