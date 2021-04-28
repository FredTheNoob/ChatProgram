using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using WebsocketServer.Classes;

namespace ChatProgram
{
    public partial class SignIn : MetroForm
    {
        public SignIn()
        {
            InitializeComponent();

            // USER CONTROLS
            usrLogin.Setup(this, usrSignUp);
            usrSignUp.Setup(this, usrLogin);
        }

        public void Login(User _user)
        {   
            Form1 form = new Form1(_user);

            // Visibility
            this.Hide();
            form.Show();
        }
    }
}
