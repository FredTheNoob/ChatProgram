using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
using WebsocketServer.Classes;
using WebSocketSharp;

namespace ChatProgram.UserControls
{
    public partial class SignUp : MetroUserControl
    {
        private Login loginControl;
        private SignIn signInForm;
        private WebSocket ws;

        public SignUp()
        {
            InitializeComponent();
        }

        public void Setup(SignIn _signInForm, Login _loginControl, WebSocket _ws)
        {
            signInForm = _signInForm;
            loginControl = _loginControl;
            ws = _ws;
        }

        public void UpdateErrorLabel(string _text)
        {
            lblError.Text = _text;
            lblError.Visible = true;
        }

        public void SetActiveControl()
        {
            ActiveControl = txtUsername;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
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

            if (txtPassword.Text != txtRetypePassword.Text)
            {
                UpdateErrorLabel("Passwords doesn't match");
                return;
            }

            ws.Send($"Register§{txtUsername.Text}§{txtPassword.Text}");
        }

        private void lblChangeToSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginControl.Show();
            loginControl.SetActiveControl();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSignUp_Click(sender, e);
        }
    }
}
