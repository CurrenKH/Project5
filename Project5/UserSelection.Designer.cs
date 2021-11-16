namespace Project5
{
    partial class UserSelection
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
            this.clientButton = new System.Windows.Forms.Button();
            this.managerButton = new System.Windows.Forms.Button();
            this.loginSelectionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clientButton
            // 
            this.clientButton.Location = new System.Drawing.Point(297, 90);
            this.clientButton.Margin = new System.Windows.Forms.Padding(4);
            this.clientButton.Name = "clientButton";
            this.clientButton.Size = new System.Drawing.Size(181, 72);
            this.clientButton.TabIndex = 5;
            this.clientButton.Text = "Client";
            this.clientButton.UseVisualStyleBackColor = true;
            this.clientButton.Click += new System.EventHandler(this.ClientButton_Click);
            // 
            // managerButton
            // 
            this.managerButton.Location = new System.Drawing.Point(79, 90);
            this.managerButton.Margin = new System.Windows.Forms.Padding(4);
            this.managerButton.Name = "managerButton";
            this.managerButton.Size = new System.Drawing.Size(181, 72);
            this.managerButton.TabIndex = 4;
            this.managerButton.Text = "Manager";
            this.managerButton.UseVisualStyleBackColor = true;
            this.managerButton.Click += new System.EventHandler(this.ManagerButton_Click);
            // 
            // loginSelectionLabel
            // 
            this.loginSelectionLabel.AutoSize = true;
            this.loginSelectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginSelectionLabel.Location = new System.Drawing.Point(167, 32);
            this.loginSelectionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.loginSelectionLabel.Name = "loginSelectionLabel";
            this.loginSelectionLabel.Size = new System.Drawing.Size(227, 32);
            this.loginSelectionLabel.TabIndex = 3;
            this.loginSelectionLabel.Text = "Login Selection";
            // 
            // UserSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 214);
            this.Controls.Add(this.clientButton);
            this.Controls.Add(this.managerButton);
            this.Controls.Add(this.loginSelectionLabel);
            this.Name = "UserSelection";
            this.Text = "UserSelection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button clientButton;
        private System.Windows.Forms.Button managerButton;
        private System.Windows.Forms.Label loginSelectionLabel;
    }
}

