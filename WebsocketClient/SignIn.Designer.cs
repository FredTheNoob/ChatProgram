namespace ChatProgram
{
    partial class SignIn
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
            this.usrSignUp = new ChatProgram.UserControls.SignUp();
            this.usrLogin = new ChatProgram.UserControls.Login();
            this.lblIP = new MetroFramework.Controls.MetroLabel();
            this.txtIP = new MetroFramework.Controls.MetroTextBox();
            this.btnConnect = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // usrSignUp
            // 
            this.usrSignUp.Location = new System.Drawing.Point(0, 25);
            this.usrSignUp.Name = "usrSignUp";
            this.usrSignUp.Size = new System.Drawing.Size(800, 450);
            this.usrSignUp.TabIndex = 0;
            this.usrSignUp.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.usrSignUp.UseSelectable = true;
            // 
            // usrLogin
            // 
            this.usrLogin.Location = new System.Drawing.Point(0, 25);
            this.usrLogin.Name = "usrLogin";
            this.usrLogin.Size = new System.Drawing.Size(800, 450);
            this.usrLogin.TabIndex = 1;
            this.usrLogin.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.usrLogin.UseSelectable = true;
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblIP.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblIP.Location = new System.Drawing.Point(356, 154);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(89, 25);
            this.lblIP.TabIndex = 2;
            this.lblIP.Text = "Server IP";
            this.lblIP.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtIP
            // 
            // 
            // 
            // 
            this.txtIP.CustomButton.Image = null;
            this.txtIP.CustomButton.Location = new System.Drawing.Point(203, 1);
            this.txtIP.CustomButton.Name = "";
            this.txtIP.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtIP.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtIP.CustomButton.TabIndex = 1;
            this.txtIP.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtIP.CustomButton.UseSelectable = true;
            this.txtIP.CustomButton.Visible = false;
            this.txtIP.Lines = new string[] {
        "localhost"};
            this.txtIP.Location = new System.Drawing.Point(288, 189);
            this.txtIP.MaxLength = 32767;
            this.txtIP.Name = "txtIP";
            this.txtIP.PasswordChar = '\0';
            this.txtIP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIP.SelectedText = "";
            this.txtIP.SelectionLength = 0;
            this.txtIP.SelectionStart = 0;
            this.txtIP.ShortcutsEnabled = true;
            this.txtIP.Size = new System.Drawing.Size(225, 23);
            this.txtIP.TabIndex = 3;
            this.txtIP.Text = "localhost";
            this.txtIP.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.txtIP.UseSelectable = true;
            this.txtIP.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtIP.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(338, 231);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(125, 39);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.btnConnect.UseSelectable = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usrLogin);
            this.Controls.Add(this.usrSignUp);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.lblIP);
            this.MaximizeBox = false;
            this.Name = "SignIn";
            this.Resizable = false;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.SignUp usrSignUp;
        private UserControls.Login usrLogin;
        private MetroFramework.Controls.MetroLabel lblIP;
        private MetroFramework.Controls.MetroTextBox txtIP;
        private MetroFramework.Controls.MetroButton btnConnect;
    }
}