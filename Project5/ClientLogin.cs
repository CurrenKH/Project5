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
            //  To change the connection format you must edit the const strings at the top of the DBManager.cs file
            //  This method sets up a connection to a MySQL database
            dbManager.SetDBConnection();
            // =======================================================

            //  Call method to read existing clients
            dbManager.ReadClientsDB();

            //  The password character is an asterisk
            //  Source: https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-create-a-password-text-box-with-the-windows-forms-textbox-control?view=netframeworkdesktop-4.8
            clientPasswordTextBox.PasswordChar = '*';
        }

        //  Declare class instance for SQL connection methods
        DBManager dbManager = new DBManager();

        //  ID to pass in another form for purchasing tickets under the account
        public static int userID;
        private void ClientLoginButton_Click(object sender, EventArgs e)
        {
            //  Reread clients in the database for new entries
            dbManager.ReadClientsDB();

            //  Check IF the inputted username AND/OR password are valid entries using Regex
            //  Source: https://stackoverflow.com/a/3435102/12985943
            if (dbManager.userList.Exists(x => x.Username == clientUsernameTextBox.Text && x.TypeID == 1 && x.Password == clientPasswordTextBox.Text))
            {
                //  For EACH client that exists in the user list, check first if the username and password fields match any
                //  user existing in that list, then assign the ID (for who is logged in sucessfully) to a variable passed
                //  to the purchasing form to log the client ID in the e_ticket table entry
                foreach (UserAccount client in dbManager.userList)
                {
                    //  Variable checking
                    if (client.Username == clientUsernameTextBox.Text && client.TypeID == 1 && client.Password == clientPasswordTextBox.Text)
                    {
                        userID = client.ID;
                    }
                }
                //  Declare new form
                ClientService clientServicePortal= new ClientService();

                //  Open form
                clientServicePortal.ShowDialog();
            }
            //  If both entries are incorrect
            else if (dbManager.userList.Exists(x => x.Username != clientUsernameTextBox.Text && x.TypeID == 2 && x.Password != clientPasswordTextBox.Text))
            {
                //  Display error message
                MessageBox.Show("Access denied. Incorrect username and password.");
            }
            //  If the username is incorrect
            else if (dbManager.userList.Exists(x => x.Username != clientUsernameTextBox.Text && x.TypeID == 2))
            {
                //  Display error message
                MessageBox.Show("Access denied. Incorrect username.");
            }
            //  If the password is incorrect
            else if (dbManager.userList.Exists(x => x.Password != clientPasswordTextBox.Text && x.TypeID == 2))
            {
                //  Display error message
                MessageBox.Show("Access denied. Incorrect password.");
            }
        }

        private void SignUpButton_Click(object sender, EventArgs e)
        {
            //  Declare form
            ClientSignup signupForm = new ClientSignup();

            //  Open new form
            signupForm.ShowDialog();
        }

        private void ClientLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
