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
    public partial class UserSelection : Form
    {


        public UserSelection()
        {
            InitializeComponent();
        }

        private void ManagerButton_Click(object sender, EventArgs e)
        {
            //  Declare form
            ManagerLogin managerLoginForm = new ManagerLogin();

            //  Show new form
            managerLoginForm.ShowDialog(this);
        }

        private void ClientButton_Click(object sender, EventArgs e)
        {
            //  Declare form
            ClientLogin clientLoginForm = new ClientLogin();

            //  Show new form
            clientLoginForm.ShowDialog(this);
        }
    }
}
