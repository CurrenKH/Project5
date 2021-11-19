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
            //  ( host_name, username, password, db_name )
            //  This method sets up a connection to a MySQL database
            dbManager.SetDBConnection("127.0.0.1", "CurrenH", "dfcg22r", "project");
            // =======================================================

            dbManager.ReadManagersDB();
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
            //  Otherwise if there is one or more invalid entries
            else
            {
                //  Display error message
                MessageBox.Show("Access denied. Manager username and/or Password are incorrect.");
            }
        }
    }
}
