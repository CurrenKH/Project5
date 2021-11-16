namespace Project5
{
    partial class Clients
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
            this.clientsListView = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clientsListView
            // 
            this.clientsListView.HideSelection = false;
            this.clientsListView.Location = new System.Drawing.Point(90, 41);
            this.clientsListView.Name = "clientsListView";
            this.clientsListView.Size = new System.Drawing.Size(591, 346);
            this.clientsListView.TabIndex = 0;
            this.clientsListView.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(307, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 29);
            this.label4.TabIndex = 18;
            this.label4.Text = "Client Portal";
            // 
            // Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 428);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clientsListView);
            this.Name = "Clients";
            this.Text = "Clients";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView clientsListView;
        private System.Windows.Forms.Label label4;
    }
}