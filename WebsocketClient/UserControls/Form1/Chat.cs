﻿using System;
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

        public Chat(string _friendName, WebSocket _ws)
        {
            InitializeComponent();

            ws = _ws;
            lblUsername.Text = _friendName;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMessage.Text)) return;
            ws.Send(txtMessage.Text);
            txtMessage.Text = "";
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
            }
        }
    }
}