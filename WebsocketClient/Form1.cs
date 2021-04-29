using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using MetroFramework.Forms;
using MetroFramework.Controls;
using WebsocketServer.Classes;

namespace ChatProgram
{
    public partial class Form1 : MetroForm
    {
        WebSocket ws;

        private User signedInUser;

        public Form1(User _user)
        {
            InitializeComponent();

            signedInUser = _user;

            // USER CONTROLS
            usrFriends.Setup(this, signedInUser);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMessage.Text)) return;
            ws.Send(txtMessage.Text);
            txtMessage.Text = "";
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // SETUP
            string host = "localhost";
            ws = new WebSocket($"ws://{host}:6969/Chat");

            // EVENTS
            ws.OnMessage += OnMessage;

            ws.Connect();

            ActiveControl = btnFriends;
            lblUsername.Text = signedInUser.name;
            LoadFriends();
        }

        public void OnMessage(object sender, MessageEventArgs e)
        {
            // Hvordan man opdaterer UIen (som kører på en main thread)
            // Kilde: https://stackoverflow.com/questions/43741059/cross-thread-operation-not-valid-control-textbox-accessed-from-a-thread-other
            lstMessages.Invoke((Action)delegate
            {
                lstMessages.Items.Add(e.Data);
                lstMessages.TopIndex = lstMessages.Items.Count - 1; // Auto scroll
            });
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
                    btnFriend.Click += btnFriendClicked;

                    pnlFriends.Controls.Add(btnFriend);
                }
            }
        }

        private void btnFriendClicked(object sender, EventArgs e)
        {
            usrFriends.Hide();
        }

        private void btnFriends_Click(object sender, EventArgs e)
        {
            usrFriends.Show();
        }
    }
}
