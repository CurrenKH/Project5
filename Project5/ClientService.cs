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
    public partial class ClientService : Form
    {
        public ClientService()
        {
            InitializeComponent();
        }

        private void PurchaseTicketButton_Click(object sender, EventArgs e)
        {
            //  Declare form
            TicketPurchase ticketPurchaseForm = new TicketPurchase();

            //  Show new form
            ticketPurchaseForm.ShowDialog(this);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //  Closes the form
            this.Close();
        }
    }
}
