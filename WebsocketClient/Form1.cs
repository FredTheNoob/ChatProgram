﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace ChatProgram
{
    public partial class Form1 : Form
    {
        WebSocket ws;

        public Form1()
        {
            InitializeComponent();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // SETUP
            string host = "77.68.159.144";
            ws = new WebSocket($"ws://{host}:6969/Chat");

            // EVENTS
            ws.OnMessage += OnMessage;

            ws.Connect();
        }

        public void OnMessage(object sender, MessageEventArgs e)
        {
            // Hvordan man opdaterer UIen (som kører på en main thread)
            // Kilde: https://stackoverflow.com/questions/43741059/cross-thread-operation-not-valid-control-textbox-accessed-from-a-thread-other
            lstMessages.Invoke((Action)delegate
            {
                lstMessages.Items.Add(e.Data);
                lstMessages.TopIndex = lstMessages.Items.Count - 1; // Auto scroll
            });
        }
    }

    
}
