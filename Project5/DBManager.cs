using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Project5
{
    class DBManager
    {
        //  Constants to use when creating connections to the database
        public const string dbHost = "127.0.0.1";
        public const string dbUsername = "CurrenH";
        public const string dbPassword = "dfcg22r";
        public const string dbName = "project";

        //  Declare lists
        public List<UserAccount> Users = new List<UserAccount>();

        //  Declare MySQL instance for connections
        public MySqlConnection dbConnection;

        //ManagerForm managerForm = new ManagerForm();

        public void SetDBConnection(string serverAddress, string username, string passwd, string dbName)
        {
            //  Set connection
            string connectionString = "Host=" + serverAddress + "; Username=" + username + "; Password=" + passwd + "; Database=" + dbName + ";";

            dbConnection = new MySqlConnection(connectionString);
        }

        public MySqlConnection CreateDBConnection(string serverAddress, string username, string passwd, string dbName)
        {
            //  String to connect to database
            string connection = "Host=" + serverAddress + "; Username=" + username + "; Password=" + passwd + "; Database=" + dbName + ";";

            dbConnection = new MySqlConnection(connection);

            return dbConnection;
        }

        public List<UserAccount> ReadManagersDB()
        {
            //  Declare account variable
            UserAccount selectedManager;

            //  Open DB connection
            dbConnection.Open();

            //  SQL query to execute in the db
            string sqlQuery = "SELECT * FROM user_account;";

            //  SQL containing the query to be executed
            MySqlCommand dbCommand = new MySqlCommand(sqlQuery, dbConnection);

            //  Stores the result of the SQL query sent to the database
            MySqlDataReader dataReader = dbCommand.ExecuteReader();

            //  Read all data entries
            while (dataReader.Read())
            {
                //  Declare user variable
                selectedManager = new UserAccount();

                //  Associate variables with read data
                selectedManager.ID = dataReader.GetInt32(0);
                selectedManager.Name = dataReader.GetString(1);
                selectedManager.Username = dataReader.GetString(2);
                selectedManager.Password = dataReader.GetString(3);
                selectedManager.EmailAddress = dataReader.GetString(4);
                selectedManager.TypeID = dataReader.GetInt32(5);
                selectedManager.SignupDate = dataReader.GetDateTime(6);

                //  Add to users list
                Users.Add(selectedManager);

            }
            //  Close DB connection
            dbConnection.Close();

            return Users;
        }

        public List<UserAccount> ReadClientsDB()
        {
            //  Declare account variable
            UserAccount selectedClient;

            //  Open DB connection
            dbConnection.Open();

            //  SQL query to execute in the db.
            string sqlQuery = "SELECT * FROM user_account;";

            //  SQL containing the query to be executed
            MySqlCommand dbCommand = new MySqlCommand(sqlQuery, dbConnection);

            //  Stores the result of the SQL query sent to the database
            MySqlDataReader dataReader = dbCommand.ExecuteReader();

            //  Read all data entries
            while (dataReader.Read())
            {
                //  Declare user variable
                selectedClient = new UserAccount();

                //  Associate variables with read data
                selectedClient.ID = dataReader.GetInt32(0);
                selectedClient.Name = dataReader.GetString(1);
                selectedClient.Username = dataReader.GetString(2);
                selectedClient.Password = dataReader.GetString(3);
                selectedClient.EmailAddress = dataReader.GetString(4);
                selectedClient.TypeID = dataReader.GetInt32(5);
                selectedClient.SignupDate = dataReader.GetDateTime(6);

                //  Add to users list
                Users.Add(selectedClient);

            }
            //  Close DB connection
            dbConnection.Close();

            return Users;
        }

        public int CreateClientDB(UserAccount newClient)
        {

            //  Declare int variable for rows affected upon changes
            int queryResult;

            //  Open DB connection
            dbConnection.Open();

            /*  SQL query to execute in the db
            string sqlQuery = "INSERT INTO user_account VALUES('" + newClient.ID + "', '" + newClient.Name + "', '" + newClient.Username + "', '" + newClient.Password
            + "', '" + newClient.EmailAddress + "', '" + newClient.TypeID + "', '" + Convert.ToDateTime(newClient.SignupDate).ToString("yyyy-MM-dd HH:mm:ss") + "');";*/

            //  SQL query to execute in the db
            string sqlQuery = "INSERT INTO user_account VALUES(@ID, @Name, @Username, @Password, @EmailAddress, @TypeID, @SignupDate);";

            //  SQL containing the query to be executed
            MySqlCommand dbCommand = new MySqlCommand(sqlQuery, dbConnection);

            //  Associate parameters with user objects
            dbCommand.Parameters.AddWithValue("@ID", newClient.ID);
            dbCommand.Parameters.AddWithValue("@Name", newClient.Name);
            dbCommand.Parameters.AddWithValue("@Username", newClient.Username);
            dbCommand.Parameters.AddWithValue("@Password", newClient.Password);
            dbCommand.Parameters.AddWithValue("@EmailAddress", newClient.EmailAddress);
            dbCommand.Parameters.AddWithValue("@TypeID", newClient.TypeID);

            //  Convert this DateTime to correctly match the format in MySQL
            dbCommand.Parameters.AddWithValue("@SignupDate", Convert.ToDateTime(newClient.SignupDate).ToString("yyyy-MM-dd HH:mm:ss"));

            //  Prepare parameters to query in DB
            dbCommand.Prepare();

            //  Result of rows affected
            queryResult = dbCommand.ExecuteNonQuery();

            //  Close DB connection
            dbConnection.Close();

            return queryResult;
        }

        
    }
}
