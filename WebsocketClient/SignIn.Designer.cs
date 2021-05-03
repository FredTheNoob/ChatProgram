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
            // SignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usrLogin);
            this.Controls.Add(this.usrSignUp);
            this.MaximizeBox = false;
            this.Name = "SignIn";
            this.Resizable = false;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.SignUp usrSignUp;
        private UserControls.Login usrLogin;
    }
}