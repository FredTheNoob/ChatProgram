
namespace ChatProgram.UserControls.Form1
{
    partial class Friends
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAddFriend = new MetroFramework.Controls.MetroLabel();
            this.txtFindUser = new MetroFramework.Controls.MetroTextBox();
            this.btnFindUser = new MetroFramework.Controls.MetroButton();
            this.lblPending = new MetroFramework.Controls.MetroLabel();
            this.pnlPending = new MetroFramework.Controls.MetroPanel();
            this.lblBlocked = new MetroFramework.Controls.MetroLabel();
            this.pnlBlocked = new MetroFramework.Controls.MetroPanel();
            this.pnlIncoming = new MetroFramework.Controls.MetroPanel();
            this.lblIncoming = new MetroFramework.Controls.MetroLabel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAddFriend
            // 
            this.lblAddFriend.AutoSize = true;
            this.lblAddFriend.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblAddFriend.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblAddFriend.Location = new System.Drawing.Point(238, 10);
            this.lblAddFriend.Name = "lblAddFriend";
            this.lblAddFriend.Size = new System.Drawing.Size(111, 25);
            this.lblAddFriend.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblAddFriend.TabIndex = 0;
            this.lblAddFriend.Text = "Add a friend";
            this.lblAddFriend.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtFindUser
            // 
            // 
            // 
            // 
            this.txtFindUser.CustomButton.Image = null;
            this.txtFindUser.CustomButton.Location = new System.Drawing.Point(323, 1);
            this.txtFindUser.CustomButton.Name = "";
            this.txtFindUser.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtFindUser.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFindUser.CustomButton.TabIndex = 1;
            this.txtFindUser.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFindUser.CustomButton.UseSelectable = true;
            this.txtFindUser.CustomButton.Visible = false;
            this.txtFindUser.Lines = new string[0];
            this.txtFindUser.Location = new System.Drawing.Point(57, 63);
            this.txtFindUser.MaxLength = 32767;
            this.txtFindUser.Name = "txtFindUser";
            this.txtFindUser.PasswordChar = '\0';
            this.txtFindUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFindUser.SelectedText = "";
            this.txtFindUser.SelectionLength = 0;
            this.txtFindUser.SelectionStart = 0;
            this.txtFindUser.ShortcutsEnabled = true;
            this.txtFindUser.Size = new System.Drawing.Size(345, 23);
            this.txtFindUser.TabIndex = 1;
            this.txtFindUser.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtFindUser.UseSelectable = true;
            this.txtFindUser.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFindUser.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnFindUser
            // 
            this.btnFindUser.Location = new System.Drawing.Point(408, 63);
            this.btnFindUser.Name = "btnFindUser";
            this.btnFindUser.Size = new System.Drawing.Size(128, 23);
            this.btnFindUser.TabIndex = 2;
            this.btnFindUser.Text = "Send Friend Request";
            this.btnFindUser.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnFindUser.UseSelectable = true;
            this.btnFindUser.Click += new System.EventHandler(this.btnFindUser_Click);
            // 
            // lblPending
            // 
            this.lblPending.AutoSize = true;
            this.lblPending.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblPending.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblPending.Location = new System.Drawing.Point(330, 113);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(206, 25);
            this.lblPending.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblPending.TabIndex = 4;
            this.lblPending.Text = "Pending Friend Requests";
            this.lblPending.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // pnlPending
            // 
            this.pnlPending.HorizontalScrollbarBarColor = true;
            this.pnlPending.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlPending.HorizontalScrollbarSize = 10;
            this.pnlPending.Location = new System.Drawing.Point(340, 141);
            this.pnlPending.Name = "pnlPending";
            this.pnlPending.Size = new System.Drawing.Size(187, 137);
            this.pnlPending.TabIndex = 5;
            this.pnlPending.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.pnlPending.VerticalScrollbar = true;
            this.pnlPending.VerticalScrollbarBarColor = true;
            this.pnlPending.VerticalScrollbarHighlightOnWheel = true;
            this.pnlPending.VerticalScrollbarSize = 10;
            // 
            // lblBlocked
            // 
            this.lblBlocked.AutoSize = true;
            this.lblBlocked.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblBlocked.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblBlocked.Location = new System.Drawing.Point(232, 287);
            this.lblBlocked.Name = "lblBlocked";
            this.lblBlocked.Size = new System.Drawing.Size(122, 25);
            this.lblBlocked.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblBlocked.TabIndex = 6;
            this.lblBlocked.Text = "Blocked Users";
            this.lblBlocked.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // pnlBlocked
            // 
            this.pnlBlocked.HorizontalScrollbarBarColor = true;
            this.pnlBlocked.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlBlocked.HorizontalScrollbarSize = 10;
            this.pnlBlocked.Location = new System.Drawing.Point(200, 315);
            this.pnlBlocked.Name = "pnlBlocked";
            this.pnlBlocked.Size = new System.Drawing.Size(187, 85);
            this.pnlBlocked.TabIndex = 6;
            this.pnlBlocked.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.pnlBlocked.VerticalScrollbar = true;
            this.pnlBlocked.VerticalScrollbarBarColor = true;
            this.pnlBlocked.VerticalScrollbarHighlightOnWheel = false;
            this.pnlBlocked.VerticalScrollbarSize = 10;
            // 
            // pnlIncoming
            // 
            this.pnlIncoming.HorizontalScrollbarBarColor = true;
            this.pnlIncoming.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlIncoming.HorizontalScrollbarSize = 10;
            this.pnlIncoming.Location = new System.Drawing.Point(67, 141);
            this.pnlIncoming.Name = "pnlIncoming";
            this.pnlIncoming.Size = new System.Drawing.Size(187, 137);
            this.pnlIncoming.TabIndex = 8;
            this.pnlIncoming.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.pnlIncoming.VerticalScrollbar = true;
            this.pnlIncoming.VerticalScrollbarBarColor = true;
            this.pnlIncoming.VerticalScrollbarHighlightOnWheel = false;
            this.pnlIncoming.VerticalScrollbarSize = 10;
            // 
            // lblIncoming
            // 
            this.lblIncoming.AutoSize = true;
            this.lblIncoming.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblIncoming.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblIncoming.Location = new System.Drawing.Point(57, 113);
            this.lblIncoming.Name = "lblIncoming";
            this.lblIncoming.Size = new System.Drawing.Size(217, 25);
            this.lblIncoming.Style = MetroFramework.MetroColorStyle.Blue;
            this.lblIncoming.TabIndex = 7;
            this.lblIncoming.Text = "Incoming Friend Requests";
            this.lblIncoming.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(0, 35);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(587, 24);
            this.lblStatus.TabIndex = 21;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Visible = false;
            // 
            // Friends
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pnlIncoming);
            this.Controls.Add(this.lblIncoming);
            this.Controls.Add(this.pnlBlocked);
            this.Controls.Add(this.lblBlocked);
            this.Controls.Add(this.pnlPending);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.btnFindUser);
            this.Controls.Add(this.txtFindUser);
            this.Controls.Add(this.lblAddFriend);
            this.Name = "Friends";
            this.Size = new System.Drawing.Size(587, 403);
            this.Style = MetroFramework.MetroColorStyle.Blue;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblAddFriend;
        private MetroFramework.Controls.MetroTextBox txtFindUser;
        private MetroFramework.Controls.MetroButton btnFindUser;
        private MetroFramework.Controls.MetroLabel lblPending;
        private MetroFramework.Controls.MetroPanel pnlPending;
        private MetroFramework.Controls.MetroLabel lblBlocked;
        private MetroFramework.Controls.MetroPanel pnlBlocked;
        private MetroFramework.Controls.MetroPanel pnlIncoming;
        private MetroFramework.Controls.MetroLabel lblIncoming;
        private System.Windows.Forms.Label lblStatus;
    }
}
