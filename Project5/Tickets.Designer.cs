namespace Project5
{
    partial class Tickets
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
            this.showtimesListBox = new System.Windows.Forms.ListBox();
            this.moviesListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ticketTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // showtimesListBox
            // 
            this.showtimesListBox.FormattingEnabled = true;
            this.showtimesListBox.ItemHeight = 16;
            this.showtimesListBox.Location = new System.Drawing.Point(462, 48);
            this.showtimesListBox.Margin = new System.Windows.Forms.Padding(4);
            this.showtimesListBox.Name = "showtimesListBox";
            this.showtimesListBox.Size = new System.Drawing.Size(289, 164);
            this.showtimesListBox.TabIndex = 20;
            // 
            // moviesListBox
            // 
            this.moviesListBox.FormattingEnabled = true;
            this.moviesListBox.ItemHeight = 16;
            this.moviesListBox.Location = new System.Drawing.Point(27, 48);
            this.moviesListBox.Margin = new System.Windows.Forms.Padding(4);
            this.moviesListBox.Name = "moviesListBox";
            this.moviesListBox.Size = new System.Drawing.Size(289, 164);
            this.moviesListBox.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Tickets sold:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(308, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 29);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ticket Portal";
            // 
            // ticketTextBox
            // 
            this.ticketTextBox.Enabled = false;
            this.ticketTextBox.Location = new System.Drawing.Point(324, 104);
            this.ticketTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ticketTextBox.Name = "ticketTextBox";
            this.ticketTextBox.ReadOnly = true;
            this.ticketTextBox.Size = new System.Drawing.Size(130, 22);
            this.ticketTextBox.TabIndex = 16;
            this.ticketTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Tickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 236);
            this.Controls.Add(this.showtimesListBox);
            this.Controls.Add(this.moviesListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ticketTextBox);
            this.Name = "Tickets";
            this.Text = "Tickets";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox showtimesListBox;
        private System.Windows.Forms.ListBox moviesListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ticketTextBox;
    }
}