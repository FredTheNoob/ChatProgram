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
    public partial class SignUp : MetroUserControl
    {
        private MetroUserControl loginControl;
        private SignIn signInForm;
        public SignUp()
        {
            InitializeComponent();
        }

        public void Setup(SignIn _signInForm, MetroUserControl _loginControl)
        {
            signInForm = _signInForm;
            loginControl = _loginControl;
        }

        private async void btnSignUp_Click(object sender, EventArgs e)
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

            if (await Database.GetInstance().DoesUserExist(txtUsername.Text) == false)
            {
                User newUser = new User(txtUsername.Text, txtPassword.Text);
                Database.GetInstance().CreateNewUser(newUser);

                this.Hide();
                signInForm.Login(newUser);
            }
            else
            {
                UpdateErrorLabel("Username already exists. Please pick another username and try again");
                return;
            }
        }

        private void UpdateErrorLabel(string _text)
        {
            lblError.Text = _text;
            lblError.Visible = true;
        }

        private void lblChangeToSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginControl.Show();
        }
    }
}
