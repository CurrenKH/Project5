﻿namespace Project5
{
    partial class TicketPurchase
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.processCompleteLabel = new System.Windows.Forms.Label();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.movieTextBox = new System.Windows.Forms.TextBox();
            this.screeningRoomTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Screening Room:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Movie:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Date:";
            // 
            // processCompleteLabel
            // 
            this.processCompleteLabel.AutoSize = true;
            this.processCompleteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.processCompleteLabel.Location = new System.Drawing.Point(126, 20);
            this.processCompleteLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.processCompleteLabel.Name = "processCompleteLabel";
            this.processCompleteLabel.Size = new System.Drawing.Size(228, 29);
            this.processCompleteLabel.TabIndex = 21;
            this.processCompleteLabel.Text = "Process Complete";
            // 
            // dateTextBox
            // 
            this.dateTextBox.Enabled = false;
            this.dateTextBox.Location = new System.Drawing.Point(159, 66);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(195, 22);
            this.dateTextBox.TabIndex = 28;
            // 
            // movieTextBox
            // 
            this.movieTextBox.Enabled = false;
            this.movieTextBox.Location = new System.Drawing.Point(159, 101);
            this.movieTextBox.Name = "movieTextBox";
            this.movieTextBox.Size = new System.Drawing.Size(195, 22);
            this.movieTextBox.TabIndex = 29;
            // 
            // screeningRoomTextBox
            // 
            this.screeningRoomTextBox.Enabled = false;
            this.screeningRoomTextBox.Location = new System.Drawing.Point(159, 136);
            this.screeningRoomTextBox.Name = "screeningRoomTextBox";
            this.screeningRoomTextBox.Size = new System.Drawing.Size(195, 22);
            this.screeningRoomTextBox.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 187);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Your ticket has been purchased.";
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(140, 208);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(203, 56);
            this.exitButton.TabIndex = 32;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // TicketPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 279);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.screeningRoomTextBox);
            this.Controls.Add(this.movieTextBox);
            this.Controls.Add(this.dateTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.processCompleteLabel);
            this.Name = "TicketPurchase";
            this.Text = "TicketPurchase";
            this.Load += new System.EventHandler(this.TicketPurchase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label processCompleteLabel;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.TextBox movieTextBox;
        private System.Windows.Forms.TextBox screeningRoomTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button exitButton;
    }
}