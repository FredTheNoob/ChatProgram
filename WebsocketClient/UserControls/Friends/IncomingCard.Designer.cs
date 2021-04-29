
namespace ChatProgram.UserControls.Friends
{
    partial class IncomingCard
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
            this.lblUsername = new MetroFramework.Controls.MetroLabel();
            this.btnDecline = new MetroFramework.Controls.MetroButton();
            this.btnAccept = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(6, 7);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(87, 23);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username";
            this.lblUsername.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // btnDecline
            // 
            this.btnDecline.Location = new System.Drawing.Point(141, 4);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(37, 27);
            this.btnDecline.TabIndex = 2;
            this.btnDecline.Text = "D";
            this.btnDecline.UseSelectable = true;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(99, 4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(37, 27);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "A";
            this.btnAccept.UseSelectable = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // IncomingCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.lblUsername);
            this.Name = "IncomingCard";
            this.Size = new System.Drawing.Size(181, 35);
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblUsername;
        private MetroFramework.Controls.MetroButton btnDecline;
        private MetroFramework.Controls.MetroButton btnAccept;
    }
}
