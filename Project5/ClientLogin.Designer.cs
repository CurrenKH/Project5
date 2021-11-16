namespace Project5
{
    partial class ClientLogin
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
            this.clientLoginLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.clientLoginButton = new System.Windows.Forms.Button();
            this.clientPasswordTextBox = new System.Windows.Forms.TextBox();
            this.clientUsernameTextBox = new System.Windows.Forms.TextBox();
            this.newUserInfoLabel = new System.Windows.Forms.Label();
            this.signUpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clientLoginLabel
            // 
            this.clientLoginLabel.AutoSize = true;
            this.clientLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientLoginLabel.Location = new System.Drawing.Point(163, 31);
            this.clientLoginLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.clientLoginLabel.Name = "clientLoginLabel";
            this.clientLoginLabel.Size = new System.Drawing.Size(153, 29);
            this.clientLoginLabel.TabIndex = 16;
            this.clientLoginLabel.Text = "Client Login";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(128, 119);
            this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(73, 17);
            this.passwordLabel.TabIndex = 15;
            this.passwordLabel.Text = "Password:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(128, 70);
            this.usernameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(77, 17);
            this.usernameLabel.TabIndex = 14;
            this.usernameLabel.Text = "Username:";
            // 
            // clientLoginButton
            // 
            this.clientLoginButton.Location = new System.Drawing.Point(178, 170);
            this.clientLoginButton.Margin = new System.Windows.Forms.Padding(4);
            this.clientLoginButton.Name = "clientLoginButton";
            this.clientLoginButton.Size = new System.Drawing.Size(124, 48);
            this.clientLoginButton.TabIndex = 13;
            this.clientLoginButton.Text = "Log In";
            this.clientLoginButton.UseVisualStyleBackColor = true;
            this.clientLoginButton.Click += new System.EventHandler(this.ClientLoginButton_Click);
            // 
            // clientPasswordTextBox
            // 
            this.clientPasswordTextBox.Location = new System.Drawing.Point(132, 138);
            this.clientPasswordTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.clientPasswordTextBox.Name = "clientPasswordTextBox";
            this.clientPasswordTextBox.Size = new System.Drawing.Size(223, 22);
            this.clientPasswordTextBox.TabIndex = 12;
            // 
            // clientUsernameTextBox
            // 
            this.clientUsernameTextBox.Location = new System.Drawing.Point(132, 90);
            this.clientUsernameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.clientUsernameTextBox.Name = "clientUsernameTextBox";
            this.clientUsernameTextBox.Size = new System.Drawing.Size(223, 22);
            this.clientUsernameTextBox.TabIndex = 11;
            // 
            // newUserInfoLabel
            // 
            this.newUserInfoLabel.AutoSize = true;
            this.newUserInfoLabel.Location = new System.Drawing.Point(163, 227);
            this.newUserInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.newUserInfoLabel.Name = "newUserInfoLabel";
            this.newUserInfoLabel.Size = new System.Drawing.Size(164, 17);
            this.newUserInfoLabel.TabIndex = 17;
            this.newUserInfoLabel.Text = "New user? Sign up here:";
            // 
            // signUpButton
            // 
            this.signUpButton.Location = new System.Drawing.Point(178, 248);
            this.signUpButton.Margin = new System.Windows.Forms.Padding(4);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(124, 44);
            this.signUpButton.TabIndex = 18;
            this.signUpButton.Text = "Sign Up";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.SignUpButton_Click);
            // 
            // ClientLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 305);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.newUserInfoLabel);
            this.Controls.Add(this.clientLoginLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.clientLoginButton);
            this.Controls.Add(this.clientPasswordTextBox);
            this.Controls.Add(this.clientUsernameTextBox);
            this.Name = "ClientLogin";
            this.Text = "ClientLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label clientLoginLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button clientLoginButton;
        private System.Windows.Forms.TextBox clientPasswordTextBox;
        private System.Windows.Forms.TextBox clientUsernameTextBox;
        private System.Windows.Forms.Label newUserInfoLabel;
        private System.Windows.Forms.Button signUpButton;
    }
}