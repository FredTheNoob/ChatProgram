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
        private SignUp signUpControl;
        private SignIn signInForm;
        private WebSocket ws;


        public Login()
        {
            InitializeComponent();
        }

        // Setup til referencer
        public void Setup(SignIn _signInForm, SignUp _SignUpControl, WebSocket _ws)
        {
            signInForm = _signInForm;
            signUpControl = _SignUpControl;
            ws = _ws;
        }

        public void UpdateErrorLabel(string _text)
        {
            lblError.Text = _text;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            lblError.Visible = true;
        }

        // Denne metode sætter den aktive control, altså vælger den en control og sætter den i fokus. I dette tilfælde vores tekstboks med brugernavn
        public void SetActiveControl()
        {
            ActiveControl = txtUsername;
        }

        // Når login knappen trykkes på
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Er tekstfeltet med brugernavnet tomt?
            if (txtUsername.Text == "")
            {
                // Fejl besked
                UpdateErrorLabel("Username cannot be empty");
                return;
            }

            // Er password feltet tomt?
            if (txtPassword.Text == "")
            {
                UpdateErrorLabel("Password cannot be empty");
                return;
            }

            // Send resten til serveren for validering
            ws.Send($"Login§{txtUsername.Text}§{txtPassword.Text}");
        }

        // Denne metode skifter fra Login til signup
        private void lblChangeToSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            signUpControl.Show();
            signUpControl.SetActiveControl(); // Vi sætter den aktive control, så man automatisk starter i brugernavns tekstfeltet, og ikke aktivt skal klikke på den
        }

        // Denne metode bruges til hvis en knap trykkes på
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnLogin_Click(sender, e); // Hvis knappen er enter kører vi login
        }
    }
}
