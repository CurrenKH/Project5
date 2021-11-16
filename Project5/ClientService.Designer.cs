namespace Project5
{
    partial class ClientService
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
            this.ticketPurchaseLabel = new System.Windows.Forms.Label();
            this.purchaseTicketButton = new System.Windows.Forms.Button();
            this.moviesPictureBox = new System.Windows.Forms.PictureBox();
            this.showtimesListBox = new System.Windows.Forms.ListBox();
            this.moviesListBox = new System.Windows.Forms.ListBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.purchaseInfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.moviesPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ticketPurchaseLabel
            // 
            this.ticketPurchaseLabel.AutoSize = true;
            this.ticketPurchaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketPurchaseLabel.Location = new System.Drawing.Point(348, 18);
            this.ticketPurchaseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ticketPurchaseLabel.Name = "ticketPurchaseLabel";
            this.ticketPurchaseLabel.Size = new System.Drawing.Size(219, 29);
            this.ticketPurchaseLabel.TabIndex = 18;
            this.ticketPurchaseLabel.Text = "Buy Tickets Here!";
            // 
            // purchaseTicketButton
            // 
            this.purchaseTicketButton.Location = new System.Drawing.Point(595, 298);
            this.purchaseTicketButton.Margin = new System.Windows.Forms.Padding(4);
            this.purchaseTicketButton.Name = "purchaseTicketButton";
            this.purchaseTicketButton.Size = new System.Drawing.Size(256, 56);
            this.purchaseTicketButton.TabIndex = 17;
            this.purchaseTicketButton.Text = "Purchase Ticket";
            this.purchaseTicketButton.UseVisualStyleBackColor = true;
            this.purchaseTicketButton.Click += new System.EventHandler(this.PurchaseTicketButton_Click);
            // 
            // moviesPictureBox
            // 
            this.moviesPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moviesPictureBox.Location = new System.Drawing.Point(22, 62);
            this.moviesPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.moviesPictureBox.Name = "moviesPictureBox";
            this.moviesPictureBox.Size = new System.Drawing.Size(293, 356);
            this.moviesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.moviesPictureBox.TabIndex = 16;
            this.moviesPictureBox.TabStop = false;
            // 
            // showtimesListBox
            // 
            this.showtimesListBox.FormattingEnabled = true;
            this.showtimesListBox.ItemHeight = 16;
            this.showtimesListBox.Location = new System.Drawing.Point(595, 62);
            this.showtimesListBox.Margin = new System.Windows.Forms.Padding(4);
            this.showtimesListBox.Name = "showtimesListBox";
            this.showtimesListBox.Size = new System.Drawing.Size(256, 228);
            this.showtimesListBox.TabIndex = 15;
            // 
            // moviesListBox
            // 
            this.moviesListBox.FormattingEnabled = true;
            this.moviesListBox.ItemHeight = 16;
            this.moviesListBox.Location = new System.Drawing.Point(323, 62);
            this.moviesListBox.Margin = new System.Windows.Forms.Padding(4);
            this.moviesListBox.Name = "moviesListBox";
            this.moviesListBox.Size = new System.Drawing.Size(264, 228);
            this.moviesListBox.TabIndex = 14;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(595, 362);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(256, 56);
            this.exitButton.TabIndex = 19;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // purchaseInfoLabel
            // 
            this.purchaseInfoLabel.AutoSize = true;
            this.purchaseInfoLabel.Location = new System.Drawing.Point(350, 294);
            this.purchaseInfoLabel.Name = "purchaseInfoLabel";
            this.purchaseInfoLabel.Size = new System.Drawing.Size(199, 17);
            this.purchaseInfoLabel.TabIndex = 20;
            this.purchaseInfoLabel.Text = "Choose a movie and showtime";
            // 
            // ClientService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 441);
            this.Controls.Add(this.purchaseInfoLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.ticketPurchaseLabel);
            this.Controls.Add(this.purchaseTicketButton);
            this.Controls.Add(this.moviesPictureBox);
            this.Controls.Add(this.showtimesListBox);
            this.Controls.Add(this.moviesListBox);
            this.Name = "ClientService";
            this.Text = "ClientService";
            ((System.ComponentModel.ISupportInitialize)(this.moviesPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ticketPurchaseLabel;
        private System.Windows.Forms.Button purchaseTicketButton;
        private System.Windows.Forms.PictureBox moviesPictureBox;
        private System.Windows.Forms.ListBox showtimesListBox;
        private System.Windows.Forms.ListBox moviesListBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label purchaseInfoLabel;
    }
}