using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using WebsocketServer.Classes;
using WebSocketSharp;
using WebSocket = WebSocketSharp.WebSocket;

namespace ChatProgram.UserControls
{
    public partial class Login : MetroUserControl
    {
        private MetroUserControl signUpControl;
        private SignIn signInForm;
        private WebSocket ws;


        public Login()
        {
            InitializeComponent();
        }

        public void Setup(SignIn _signInForm, MetroUserControl _SignUpControl, WebSocket _ws)
        {
            signInForm = _signInForm;
            signUpControl = _SignUpControl;
            ws = _ws;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                UpdateErrorLabel("Username cannot be empty");
                return;
            }

            if (txtPassword.Text == "")
            {
                UpdateErrorLabel("Password cannot be empty");
                return;
            }

            ws.Send($"Login§{txtUsername.Text}§{txtPassword.Text}");


        }

        private void UpdateErrorLabel(string _text)
        {
            lblError.Text = _text;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.Visible = true;
        }

        private void lblChangeToSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            signUpControl.Show();
        }
    }
}
