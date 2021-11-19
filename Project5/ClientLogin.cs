using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Project5
{
    public partial class ClientLogin : Form
    {
        public ClientLogin()
        {
            InitializeComponent();

            //             == FORMAT ==
            //  ( host_name, username, password, db_name )
            //  This method sets up a connection to a MySQL database
            dbManager.SetDBConnection("127.0.0.1", "CurrenH", "dfcg22r", "project");
            // =======================================================

            //  Call method to read existing clients
            dbManager.ReadClientsDB();
        }

        //  Declare class instance for SQL connection methods
        DBManager dbManager = new DBManager();

        private void ClientLoginButton_Click(object sender, EventArgs e)
        {
            //  Reread clients in the database for new entries
            dbManager.ReadClientsDB();

            //  Check IF the inputted username AND/OR password are valid entries using Regex
            //  Source: https://stackoverflow.com/a/3435102/12985943
            if (dbManager.userList.Exists(x => x.Username == clientUsernameTextBox.Text && x.TypeID == 1 && x.Password == clientPasswordTextBox.Text))
            {
                //  Declare new form
                ClientService clientServicePortal= new ClientService();

                //  Open form
                clientServicePortal.ShowDialog();
            }
            //  Otherwise if there is one or more invalid entries
            else
            {
                //  Display error message
                MessageBox.Show("Access denied. Client username and/or Password are incorrect.");
            }
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            //  Declare form
            ClientSignup signupForm = new ClientSignup();

            //  Open new form
            signupForm.ShowDialog();
        }
    }
}
