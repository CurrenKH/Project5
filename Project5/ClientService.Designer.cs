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
            this.components = new System.ComponentModel.Container();
            this.ticketPurchaseLabel = new System.Windows.Forms.Label();
            this.purchaseTicketButton = new System.Windows.Forms.Button();
            this.moviePictureBox = new System.Windows.Forms.PictureBox();
            this.showtimesListBox = new System.Windows.Forms.ListBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.purchaseInfoLabel = new System.Windows.Forms.Label();
            this.movieImageList = new System.Windows.Forms.ImageList(this.components);
            this.movieListView = new System.Windows.Forms.ListView();
            this.movieImageLabel = new System.Windows.Forms.Label();
            this.movieTitleLabel = new System.Windows.Forms.Label();
            this.movieShowtimeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.moviePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ticketPurchaseLabel
            // 
            this.ticketPurchaseLabel.AutoSize = true;
            this.ticketPurchaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketPurchaseLabel.Location = new System.Drawing.Point(348, 2);
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
            // moviePictureBox
            // 
            this.moviePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.moviePictureBox.Location = new System.Drawing.Point(22, 62);
            this.moviePictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.moviePictureBox.Name = "moviePictureBox";
            this.moviePictureBox.Size = new System.Drawing.Size(293, 356);
            this.moviePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.moviePictureBox.TabIndex = 16;
            this.moviePictureBox.TabStop = false;
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
            this.showtimesListBox.SelectedIndexChanged += new System.EventHandler(this.ShowtimesListBox_SelectedIndexChanged);
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
            this.purchaseInfoLabel.Location = new System.Drawing.Point(350, 401);
            this.purchaseInfoLabel.Name = "purchaseInfoLabel";
            this.purchaseInfoLabel.Size = new System.Drawing.Size(199, 17);
            this.purchaseInfoLabel.TabIndex = 20;
            this.purchaseInfoLabel.Text = "Choose a movie and showtime";
            // 
            // movieImageList
            // 
            this.movieImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.movieImageList.ImageSize = new System.Drawing.Size(255, 255);
            this.movieImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // movieListView
            // 
            this.movieListView.HideSelection = false;
            this.movieListView.Location = new System.Drawing.Point(324, 62);
            this.movieListView.Name = "movieListView";
            this.movieListView.Size = new System.Drawing.Size(264, 336);
            this.movieListView.TabIndex = 21;
            this.movieListView.UseCompatibleStateImageBehavior = false;
            this.movieListView.SelectedIndexChanged += new System.EventHandler(this.MovieListView_SelectedIndexChanged);
            // 
            // movieImageLabel
            // 
            this.movieImageLabel.AutoSize = true;
            this.movieImageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieImageLabel.Location = new System.Drawing.Point(18, 38);
            this.movieImageLabel.Name = "movieImageLabel";
            this.movieImageLabel.Size = new System.Drawing.Size(59, 20);
            this.movieImageLabel.TabIndex = 22;
            this.movieImageLabel.Text = "Image";
            // 
            // movieTitleLabel
            // 
            this.movieTitleLabel.AutoSize = true;
            this.movieTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieTitleLabel.Location = new System.Drawing.Point(320, 39);
            this.movieTitleLabel.Name = "movieTitleLabel";
            this.movieTitleLabel.Size = new System.Drawing.Size(68, 20);
            this.movieTitleLabel.TabIndex = 23;
            this.movieTitleLabel.Text = "Movies";
            // 
            // movieShowtimeLabel
            // 
            this.movieShowtimeLabel.AutoSize = true;
            this.movieShowtimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movieShowtimeLabel.Location = new System.Drawing.Point(591, 39);
            this.movieShowtimeLabel.Name = "movieShowtimeLabel";
            this.movieShowtimeLabel.Size = new System.Drawing.Size(100, 20);
            this.movieShowtimeLabel.TabIndex = 24;
            this.movieShowtimeLabel.Text = "Showtimes";
            // 
            // ClientService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 441);
            this.Controls.Add(this.movieShowtimeLabel);
            this.Controls.Add(this.movieTitleLabel);
            this.Controls.Add(this.movieImageLabel);
            this.Controls.Add(this.movieListView);
            this.Controls.Add(this.purchaseInfoLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.ticketPurchaseLabel);
            this.Controls.Add(this.purchaseTicketButton);
            this.Controls.Add(this.moviePictureBox);
            this.Controls.Add(this.showtimesListBox);
            this.Name = "ClientService";
            this.Text = "ClientService";
            this.Load += new System.EventHandler(this.ClientService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.moviePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ticketPurchaseLabel;
        private System.Windows.Forms.Button purchaseTicketButton;
        private System.Windows.Forms.PictureBox moviePictureBox;
        private System.Windows.Forms.ListBox showtimesListBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label purchaseInfoLabel;
        private System.Windows.Forms.ImageList movieImageList;
        private System.Windows.Forms.ListView movieListView;
        private System.Windows.Forms.Label movieImageLabel;
        private System.Windows.Forms.Label movieTitleLabel;
        private System.Windows.Forms.Label movieShowtimeLabel;
    }
}