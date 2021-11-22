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
    public partial class ManagerLogin : Form
    {
        public ManagerLogin()
        {
            InitializeComponent();

            //             == FORMAT ==
            //  To change the connection format you must edit the const strings at the top of the DBManager.cs file
            //  This method sets up a connection to a MySQL database
            dbManager.SetDBConnection();
            // =======================================================

            //  Call method to read existing managers
            dbManager.ReadManagersDB();

            //  The password character is an asterisk
            //  Source: https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-create-a-password-text-box-with-the-windows-forms-textbox-control?view=netframeworkdesktop-4.8
            managerPasswordTextBox.PasswordChar = '*';
        }

        //  Declare class instance for SQL connection methods
        DBManager dbManager = new DBManager();

        //List<UserAccount> Users = new List<UserAccount>();

        private void ManagerLoginButton_Click(object sender, EventArgs e)
        {

            //  Check IF the inputted username AND/OR password are valid entries using Regex
            //  Source: https://stackoverflow.com/a/3435102/12985943
            if (dbManager.userList.Exists(x => x.Username == managerUsernameTextBox.Text && x.TypeID == 2 && x.Password == managerPasswordTextBox.Text))
            {
                //  Declare form
                ManagerForm managerPortal = new ManagerForm();

                //  Display new form
                managerPortal.ShowDialog();
            }
            //  If both entries are incorrect
            else if (dbManager.userList.Exists(x => x.Username != managerUsernameTextBox.Text && x.TypeID == 2 && x.Password != managerPasswordTextBox.Text))
            {
                //  Display error message
                MessageBox.Show("Access denied. Incorrect username and password.");
            }
            //  If the username is incorrect
            else if (dbManager.userList.Exists(x => x.Username != managerUsernameTextBox.Text && x.TypeID == 2))
            {
                //  Display error message
                MessageBox.Show("Access denied. Incorrect username.");
            }
            //  If the password is incorrect
            else if (dbManager.userList.Exists(x => x.Password != managerPasswordTextBox.Text && x.TypeID == 2))
            {
                //  Display error message
                MessageBox.Show("Access denied. Incorrect password.");
            }
        }

        private void ManagerLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
