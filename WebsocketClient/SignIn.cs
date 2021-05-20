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
using MetroFramework.Controls;

namespace ChatProgram
{
    public partial class SignIn : MetroForm
    {
        private WebSocket ws;

        public SignIn()
        {
            InitializeComponent();

            usrLogin.Hide();
            usrSignUp.Hide();
        }

        // Dette event kører når vi modtager noget fra serveren. Det vi modtager er hvorvidt validationen er fuldført og bruger data
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

        // Når vi trykker på tilslut knappen
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtIP.Text == "")
            {
                MetroMessageBox.Show(this.Owner, "The IP field cannot be empty", "IP - Error");
                return;
            }

            // Lav en ny websocket på port 6969
            ws = new WebSocket($"ws://{txtIP.Text}:6969/Chat");

            // Opsæt events
            ws.OnMessage += WsOnMessage;
            ws.OnOpen += OnOpen;
            ws.OnClose += OnClose;
            ws.OnError += OnError;

            // Tilslut
            ws.Connect();
        }

        // Når vores websocket åbnes
        private void OnOpen(object sender, EventArgs e)
        {
            // USER CONTROLS
            usrLogin.Setup(this, usrSignUp, ws);
            usrSignUp.Setup(this, usrLogin, ws);

            usrSignUp.Show();
            usrLogin.Show();
            usrLogin.SetActiveControl();

            ws.OnOpen -= OnOpen;
        }

        // Når vores websocket lukkes
        private void OnClose(object sender, CloseEventArgs e)
        {
            if (e.Code == 1005) return; // Hvis vi støder på exit koden 1005 ved vi at brugeren selv har lukket programmet
            MetroMessageBox.Show(this.Owner, $"Websocket closed {e.Code}: {e.Reason}");
        }

        // Når vores websocket får en fejl
        private void OnError(object sender, ErrorEventArgs e) => MetroMessageBox.Show(this.Owner, $"Error occured with websocket: {e.Message}");
    }
}
