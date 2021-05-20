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
using WebSocketSharp;

namespace ChatProgram.UserControls.Form1
{
    public partial class Chat : MetroUserControl
    {
        private readonly WebSocket ws;
        public Chat()
        {
            InitializeComponent();
        }

        // Når vi konstruere et Chat objekt kan et overload være at passere vennens navn samt vores websocket
        public Chat(string _friendName, WebSocket _ws)
        {
            InitializeComponent();

            ws = _ws;
            lblUsername.Text = _friendName;
        }

        // Send bruges til at sende en besked til en anden bruger
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMessage.Text)) return; // Hvis tekstfeltet er tomt sender vi ikke noget til serveren
            if (txtMessage.Text.Contains('§')) return; // Hvis tekstfeltet indeholder dette symbol § returnerer vi da vi bruger denne som seperator på serveren

            string msg = $"Message§{lblUsername.Text}§{txtMessage.Text}"; // Vi laver et data objekt med string literals og bruger § som seperator
            ws.Send(msg); // Vi sender vores data til serveren
            txtMessage.Text = ""; // Vi tømmer tekstfeltet
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            // Hvis der trykkes enter
            if (e.KeyCode == Keys.Enter)
            {
                // Kør send metoden
                btnSend_Click(sender, e);

                // Dette forhindrer den trælse error lyd når man trykker enter
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // AddMessage er public så vi kan kalde den udefra hvis vi modtager en besked. Den tilføjer i alt sin enkelthed noget text til listboksen på usercontrollen
        public void AddMessage(string text)
        {
            lstMessages.Items.Add(text);
        }
    }
}
