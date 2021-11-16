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
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void TicketPortalButton_Click(object sender, EventArgs e)
        {
            //  Declare form
            Tickets ticketPortal = new Tickets();

            //  Show new form
            ticketPortal.ShowDialog(this);
        }

        private void ClientPortalButton_Click(object sender, EventArgs e)
        {
            //  Declare form
            Clients clientPortal = new Clients();

            //  Show new form
            clientPortal.ShowDialog(this);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //  Close the form
            this.Close();
        }
    }
}
