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

namespace ChatProgram.UserControls
{
    public partial class Login : MetroUserControl
    {
        private MetroUserControl signUpControl;
        private SignIn signInForm;

        public Login()
        {
            InitializeComponent();
        }

        public void Setup(SignIn _signInForm, MetroUserControl _SignUpControl)
        {
            signInForm = _signInForm;
            signUpControl = _SignUpControl;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
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

            User user = await Database.GetInstance().FindUser(txtUsername.Text);
            if (user == null)
            {
                UpdateErrorLabel("Username is incorrect");
                return;
            }

            if (user.password != txtPassword.Text)
            {
                UpdateErrorLabel("Password is incorrect");
                return;
            }

            this.Hide();
            signInForm.Login(user);
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
