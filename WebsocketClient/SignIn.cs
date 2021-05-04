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
using Newtonsoft.Json;
using WebsocketServer.Classes;
using WebSocketSharp;

namespace ChatProgram
{
    public partial class SignIn : MetroForm
    {
        private WebSocket ws;

        public SignIn()
        {
            InitializeComponent();

            ws = new WebSocket("ws://localhost:6969/Chat");
            ws.Connect();


            ws.OnMessage += WsOnMessage;


            // USER CONTROLS
            usrLogin.Setup(this, usrSignUp, ws);
            usrSignUp.Setup(this, usrLogin, ws);
        }

        private void WsOnMessage(object sender, MessageEventArgs e)
        {
            var _user = JsonConvert.DeserializeObject<User>(e.Data);

            ws.OnMessage -= WsOnMessage;

            Form1 form = new Form1(_user, ws);

            // Visibility
            this.Invoke((Action)delegate
            {
                this.Hide();
            });

            form.Invoke((Action) delegate
            {
                form.Show();
            });
        }
    }
}
