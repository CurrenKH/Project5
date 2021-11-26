using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project5
{
    public partial class TicketPurchase : Form
    {
        public TicketPurchase()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //  Closes the form
            this.Close();
        }

        private void TicketPurchase_Load(object sender, EventArgs e)
        {
            //  Associate data values from previous form to this one with ticket information
            dateTextBox.Text = ClientService.purchaseTime.ToString();
            movieTextBox.Text = ClientService.movieTitle;
            screeningRoomTextBox.Text = ClientService.roomCode;
        }
    }
}
