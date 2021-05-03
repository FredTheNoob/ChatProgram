
namespace ChatProgram
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new MetroFramework.Controls.MetroLabel();
            this.btnFriends = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pnlFriends = new MetroFramework.Controls.MetroPanel();
            this.usrFriends = new ChatProgram.UserControls.Form1.Friends();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(334, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(133, 13);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Chat Program - Version 1.0";
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(582, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(126, 23);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblUsername.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btnFriends
            // 
            this.btnFriends.Location = new System.Drawing.Point(12, 12);
            this.btnFriends.Name = "btnFriends";
            this.btnFriends.Size = new System.Drawing.Size(187, 38);
            this.btnFriends.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnFriends.TabIndex = 6;
            this.btnFriends.Text = "Friends";
            this.btnFriends.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnFriends.UseSelectable = true;
            this.btnFriends.Click += new System.EventHandler(this.btnFriends_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(54, 60);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(103, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Direct Messages";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // pnlFriends
            // 
            this.pnlFriends.HorizontalScrollbarBarColor = true;
            this.pnlFriends.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlFriends.HorizontalScrollbarSize = 10;
            this.pnlFriends.Location = new System.Drawing.Point(12, 83);
            this.pnlFriends.Name = "pnlFriends";
            this.pnlFriends.Size = new System.Drawing.Size(187, 355);
            this.pnlFriends.TabIndex = 8;
            this.pnlFriends.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.pnlFriends.VerticalScrollbar = true;
            this.pnlFriends.VerticalScrollbarBarColor = true;
            this.pnlFriends.VerticalScrollbarHighlightOnWheel = false;
            this.pnlFriends.VerticalScrollbarSize = 10;
            // 
            // usrFriends
            // 
            this.usrFriends.Location = new System.Drawing.Point(205, 35);
            this.usrFriends.Name = "usrFriends";
            this.usrFriends.Size = new System.Drawing.Size(587, 403);
            this.usrFriends.Style = MetroFramework.MetroColorStyle.Blue;
            this.usrFriends.TabIndex = 9;
            this.usrFriends.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.usrFriends.UseSelectable = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usrFriends);
            this.Controls.Add(this.pnlFriends);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnFriends);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Resizable = false;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private MetroFramework.Controls.MetroLabel lblUsername;
        private MetroFramework.Controls.MetroButton btnFriends;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel pnlFriends;
        private UserControls.Form1.Friends usrFriends;
    }
}

