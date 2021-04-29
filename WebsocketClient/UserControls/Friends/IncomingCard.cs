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
    public partial class IncomingCard : MetroUserControl
    {
        public delegate void OnFinish(IncomingCard _card);
        public event OnFinish Finished;

        private User signedInUser;
        private User pendingUser;

        public IncomingCard()
        {
            InitializeComponent();
        }

        public IncomingCard(User _signedInUser, User _pendingUser)
        {
            InitializeComponent();

            this.Name = _pendingUser.name;
            signedInUser = _signedInUser;
            pendingUser = _pendingUser;
            lblUsername.Text = _pendingUser.name;
        }

        private async void btnAccept_Click(object sender, EventArgs e)
        {
            await RemovePending();
            await signedInUser.AcceptFriendRequest(pendingUser);

            Finished(this);
        }

        private async void btnDecline_Click(object sender, EventArgs e)
        {
            await RemovePending();
            Finished(this);
        }

        private async Task RemovePending()
        {
            await pendingUser.RemoveFriendRequest(signedInUser);
        }
    }
}
