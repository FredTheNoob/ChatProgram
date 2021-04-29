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

namespace ChatProgram.UserControls.Friends
{
    public partial class PendingCard : MetroUserControl
    {
        public delegate void OnRemove(PendingCard _card);
        public event OnRemove Removed;

        private User signedInUser;
        private User pendingUser;

        public PendingCard()
        {
            InitializeComponent();
        }

        public PendingCard(User _signedInUser, User _pendingUser)
        {
            InitializeComponent();

            this.Name = _pendingUser.name;
            signedInUser = _signedInUser;
            pendingUser = _pendingUser;
            lblUsername.Text = _pendingUser.name;
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            await signedInUser.RemoveFriendRequest(pendingUser);
            Removed(this);
        }
    }
}
