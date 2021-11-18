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
    public partial class ClientSignup : Form
    {
        public ClientSignup()
        {
            InitializeComponent();

            //             == FORMAT ==
            //  ( host_name, username, password, db_name )
            //  This method sets up a connection to a MySQL database
            dbManager.SetDBConnection("127.0.0.1", "CurrenH", "dfcg22r", "project");
            // =======================================================
        }

        //  Declare class instance for SQL connection methods
        DBManager dbManager = new DBManager();

        private void CreateAccountButton_Click(object sender, EventArgs e)
        {
            //  Declare random variable for ID
            Random rand = new Random();
            int idNum = rand.Next(10003, 20000);

            /*int idNum = 10000;

            //  Loop to count idNum upwards per user entry
            for (int i = 0; i < dbManager.Users.Count; i++)
            {
                idNum++;
            }*/

            //  Declare client
            UserAccount newClient = new UserAccount();

            newClient.ID = int.Parse(idNum.ToString());
            newClient.Name = nameTextBox.Text;
            newClient.Username = usernameTextBox.Text;
            newClient.Password = passwordTextBox.Text;
            newClient.EmailAddress = emailTextBox.Text;

            //  Declare that the account being created is a client
            newClient.TypeID = 1;
            newClient.SignupDate = DateTime.Now;

            //  Method to create new client
            dbManager.CreateClientDB(newClient);

            //  Close the form
            this.Close();
        }
    }
}
