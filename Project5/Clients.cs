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
    public partial class Clients : Form
    {
        public Clients()
        {
            InitializeComponent();

            //             == FORMAT ==
            //  ( host_name, username, password, db_name )
            //  This method sets up a connection to a MySQL database
            dbManager.SetDBConnection("127.0.0.1", "CurrenH", "dfcg22r", "project");
            // =======================================================

            //  Read data method
            ReadClientsDB();
        }

        //  Declare class instance for SQL connection methods
        DBManager dbManager = new DBManager();

        //  Declare user list
        List<UserAccount> userList = new List<UserAccount>();

        private List<UserAccount> ReadClientsDB()
        {
            //  Declare user account
            UserAccount readUser;

            //  Open DB connection
            dbManager.dbConnection.Open();

            //  SQL query to execute in the db
            string sqlQuery = "SELECT * FROM user_account;";

            //  SQL containing the query to be executed
            MySqlCommand dbCommand = new MySqlCommand(sqlQuery, dbManager.dbConnection);

            //  SQL query sent to the database
            MySqlDataReader dataReader = dbCommand.ExecuteReader();

            //  Read all data entries
            while (dataReader.Read())
            {
                //  Declare user account
                readUser = new UserAccount();

                //  Associate variables with read data
                readUser.ID = dataReader.GetInt32(0);
                readUser.Name = dataReader.GetString(1);
                readUser.Username = dataReader.GetString(2);
                readUser.Password = dataReader.GetString(3);
                readUser.EmailAddress = dataReader.GetString(4);
                readUser.TypeID = dataReader.GetInt32(5);
                readUser.SignupDate = dataReader.GetDateTime(6);

                //  If the type ID is read as a client (#1)
                if (readUser.TypeID == 1)
                {
                    //  Add to user list
                    userList.Add(readUser);

                    //  Add client name to ListBox
                    clientsListBox.Items.Add(readUser.Name);
                }
            }
            //  Close DB connection
            dbManager.dbConnection.Close();

            return userList;
        }

        private void ClientsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  if a ListBox item is not selected
            if (clientsListBox.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Select a client.");
            }
            //  Otherwise
            else
            {
                //  Set int variable to selected ListBox item in array (#0)
                int index = clientsListBox.SelectedIndices[0];

                //  Fields to display information by the client item
                nameTextBox.Text = userList[index].Name;
                usernameTextBox.Text = userList[index].Username;
                passwordTextBox.Text = userList[index].Password;
                emailTextBox.Text = userList[index].EmailAddress;
                signupDateTextBox.Text = userList[index].SignupDate.ToString();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //  Closes the form
            this.Close();
        }
    }
}
