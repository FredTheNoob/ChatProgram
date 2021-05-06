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
using MetroFramework;

namespace ChatProgram
{
    public partial class SignIn : MetroForm
    {
        private WebSocket ws;

        public SignIn()
        {
            InitializeComponent();

            // USER CONTROLS
            usrLogin.Setup(this, usrSignUp, ws);
            usrSignUp.Setup(this, usrLogin, ws);

            usrLogin.Hide();
            usrSignUp.Hide();
        }

        private void WsOnMessage(object sender, MessageEventArgs e)
        {
            // Visibility
            this.Invoke((Action)delegate
            {
                if (e.Data.Contains("§Login"))
                {
                    usrLogin.UpdateErrorLabel(e.Data.Remove(0, 1));
                    return;
                }
                else if (e.Data.Contains("§Register"))
                {
                    usrSignUp.UpdateErrorLabel(e.Data.Remove(0, 1));
                    return;
                }

                var _user = JsonConvert.DeserializeObject<User>(e.Data);

                ws.OnMessage -= WsOnMessage;

                this.Hide();

                Form form = new Form1(_user, ws);
                form.Show();
            });
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtIP.Text == "")
            {
                MetroMessageBox.Show(this.Owner, "The IP field cannot be empty", "IP - Error");
                return;
            }

            ws = new WebSocket($"ws://{txtIP.Text}:6969/Chat");

            ws.OnMessage += WsOnMessage;
            ws.OnOpen += OnOpen;
            ws.OnError += OnError;

            ws.Connect();
        }

        private void OnOpen(object sender, EventArgs e)
        {
            usrSignUp.Show();
            usrLogin.Show();

            ws.OnOpen -= OnOpen;
        }

        private void OnError(object sender, ErrorEventArgs e) => MetroMessageBox.Show(this.Owner, $"Error occured with websocket: {e.Message}");
    }
}
