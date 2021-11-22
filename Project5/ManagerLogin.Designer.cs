namespace Project5
{
    partial class ManagerLogin
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
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.managerLoginButton = new System.Windows.Forms.Button();
            this.managerPasswordTextBox = new System.Windows.Forms.TextBox();
            this.managerUsernameTextBox = new System.Windows.Forms.TextBox();
            this.managerLoginLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(131, 149);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(73, 17);
            this.passwordLabel.TabIndex = 9;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(131, 100);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(77, 17);
            this.usernameLabel.TabIndex = 8;
            this.usernameLabel.Text = "Username:";
            // 
            // managerLoginButton
            // 
            this.managerLoginButton.Location = new System.Drawing.Point(181, 200);
            this.managerLoginButton.Margin = new System.Windows.Forms.Padding(4);
            this.managerLoginButton.Name = "managerLoginButton";
            this.managerLoginButton.Size = new System.Drawing.Size(124, 48);
            this.managerLoginButton.TabIndex = 7;
            this.managerLoginButton.Text = "Log In";
            this.managerLoginButton.UseVisualStyleBackColor = true;
            this.managerLoginButton.Click += new System.EventHandler(this.ManagerLoginButton_Click);
            // 
            // managerPasswordTextBox
            // 
            this.managerPasswordTextBox.Location = new System.Drawing.Point(135, 168);
            this.managerPasswordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.managerPasswordTextBox.Name = "managerPasswordTextBox";
            this.managerPasswordTextBox.Size = new System.Drawing.Size(223, 22);
            this.managerPasswordTextBox.TabIndex = 6;
            // 
            // managerUsernameTextBox
            // 
            this.managerUsernameTextBox.Location = new System.Drawing.Point(135, 120);
            this.managerUsernameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.managerUsernameTextBox.Name = "managerUsernameTextBox";
            this.managerUsernameTextBox.Size = new System.Drawing.Size(223, 22);
            this.managerUsernameTextBox.TabIndex = 5;
            // 
            // managerLoginLabel
            // 
            this.managerLoginLabel.AutoSize = true;
            this.managerLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerLoginLabel.Location = new System.Drawing.Point(153, 46);
            this.managerLoginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.managerLoginLabel.Name = "managerLoginLabel";
            this.managerLoginLabel.Size = new System.Drawing.Size(187, 29);
            this.managerLoginLabel.TabIndex = 10;
            this.managerLoginLabel.Text = "Manager Login";
            // 
            // ManagerLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 305);
            this.Controls.Add(this.managerLoginLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.managerLoginButton);
            this.Controls.Add(this.managerPasswordTextBox);
            this.Controls.Add(this.managerUsernameTextBox);
            this.Name = "ManagerLogin";
            this.Text = "ManagerLogin";
            this.Load += new System.EventHandler(this.ManagerLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button managerLoginButton;
        private System.Windows.Forms.TextBox managerPasswordTextBox;
        private System.Windows.Forms.TextBox managerUsernameTextBox;
        private System.Windows.Forms.Label managerLoginLabel;
    }
}