﻿using System;
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
        public List<UserAccount> userList = new List<UserAccount>();

        //  Declare MySQL instance for connections
        public MySqlConnection dbConnection;

        //ManagerForm managerForm = new ManagerForm();

        public void SetDBConnection()
        {
            //  Set connection
            string connectionString = "Host=" + dbHost + "; Username=" + dbUsername + "; Password=" + dbPassword + "; Database=" + dbName + ";";

            dbConnection = new MySqlConnection(connectionString);
        }

        public MySqlConnection CreateDBConnection()
        {
            //  String to connect to database
            string connection = "Host=" + dbHost + "; Username=" + dbUsername + "; Password=" + dbPassword + "; Database=" + dbName + ";";

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
                userList.Add(selectedManager);

            }
            //  Close DB connection
            dbConnection.Close();

            return userList;
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
                userList.Add(selectedClient);

            }
            //  Close DB connection
            dbConnection.Close();

            return userList;
        }

        public int CreateClientDB(UserAccount newClient)
        {
            try
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
                MySqlCommand dbCommand2 = new MySqlCommand(sqlQuery, dbConnection);

                //  Associate parameters with user objects
                dbCommand2.Parameters.AddWithValue("@ID", newClient.ID);
                dbCommand2.Parameters.AddWithValue("@Name", newClient.Name);
                dbCommand2.Parameters.AddWithValue("@Username", newClient.Username);
                dbCommand2.Parameters.AddWithValue("@Password", newClient.Password);
                dbCommand2.Parameters.AddWithValue("@EmailAddress", newClient.EmailAddress);
                dbCommand2.Parameters.AddWithValue("@TypeID", newClient.TypeID);

                //  Convert this DateTime to correctly match the format in MySQL
                dbCommand2.Parameters.AddWithValue("@SignupDate", Convert.ToDateTime(newClient.SignupDate).ToString("yyyy-MM-dd HH:mm:ss"));

                //  Prepare parameters to query in DB
                dbCommand2.Prepare();

                //  Result of rows affected
                queryResult = dbCommand2.ExecuteNonQuery();

                //  Close DB connection
                dbConnection.Close();

                return queryResult;
            }
            catch
            {
                //  Error message
                Console.WriteLine("Error adding new client.");

                //  Open and close connection upon an error
                MySqlConnection dbConnection2 = CreateDBConnection();

                dbConnection2.Close();

                return 0;
            }
        }

        public int AddScreeningRoomDB(ScreeningRoom addScreeningRoom)
        {
            try
            {
                //  Open DB connection
                dbConnection.Open();

                //  Declare int variable for rows affected upon changes
                int queryResult;

                //  SQL query to execute in the db
                string sqlQuery = "INSERT INTO screening_room VALUES(@Code, @Capacity, @Description);";

                //  SQL containing the query to be executed
                MySqlCommand dbCommand3 = new MySqlCommand(sqlQuery, dbConnection);

                //  Associate parameters with screening room objects
                dbCommand3.Parameters.AddWithValue("@Code", addScreeningRoom.Code);
                dbCommand3.Parameters.AddWithValue("@Capacity", addScreeningRoom.Capacity);
                dbCommand3.Parameters.AddWithValue("@Description", addScreeningRoom.Description);

                //  Prepare parameters to query in DB
                dbCommand3.Prepare();

                //  Result of rows affected
                queryResult = dbCommand3.ExecuteNonQuery();

                //  Close DB connection
                dbConnection.Close();

                return queryResult;
            }
            catch
            {
                //  Error message
                Console.WriteLine("Error adding screening room.");

                //  Open and close connection upon an error
                MySqlConnection dbConnection3 = CreateDBConnection();

                dbConnection3.Close();

                return 0;
            }
        }

        public int ModifyScreeningRoomDB(ScreeningRoom modifyScreeningRoom)
        {
            try
            {
                //  Open DB connection
                dbConnection.Open();

                //  Declare int variable for rows affected upon changes
                int queryResult;

                //  SQL query to execute in the db           
                string sqlQuery = "UPDATE screening_room SET capacity = @Capacity, description = @Description WHERE code = @Code;";

                //  SQL containing the query to be executed
                MySqlCommand dbCommand5 = new MySqlCommand(sqlQuery, dbConnection);

                //  Associate parameters with screening room objects
                dbCommand5.Parameters.AddWithValue("@Code", modifyScreeningRoom.Code);
                dbCommand5.Parameters.AddWithValue("@Capacity", modifyScreeningRoom.Capacity);
                dbCommand5.Parameters.AddWithValue("@Description", modifyScreeningRoom.Description);

                //  Prepare parameters to query in DB
                dbCommand5.Prepare();

                //  Result of rows affected
                queryResult = dbCommand5.ExecuteNonQuery();

                //  Close DB connection
                dbConnection.Close();

                return queryResult;
            }
            catch
            {
                //  Error message
                Console.WriteLine("Error updating screening room.");

                //  Open and close connection upon an error
                MySqlConnection dbConnection5 = CreateDBConnection();

                dbConnection5.Close();

                return 0;
            }
        }
        
        public int DeleteShowtimeDB(Showtime deleteShowtime)
        {
            try
            {
                //  Open DB connection
                dbConnection.Open();

                //  Declare int variables for rows affected upon changes
                int queryResult;
                int queryResult2;

                //  ----Delete e_tickets associated with showtime if any exist first to prevent foreign key error----

                //  SQL query to execute in the db
                string sqlQuery = "DELETE FROM e_ticket WHERE showtime_id = @ID;";

                //  SQL containing the query to be executed
                MySqlCommand dbCommand6 = new MySqlCommand(sqlQuery, dbConnection);

                //  Associate parameter with showtime object
                dbCommand6.Parameters.AddWithValue("@ID", deleteShowtime.ID);

                //  Prepare parameters to query in DB
                dbCommand6.Prepare();

                //  Result of rows affected
                queryResult = dbCommand6.ExecuteNonQuery();


                //  SQL query to execute in the db
                string sqlQuery2 = "DELETE FROM showtime WHERE id = @ID;";

                //  SQL containing the query to be executed
                MySqlCommand dbCommand7 = new MySqlCommand(sqlQuery2, dbConnection);

                //  Associate parameter with showtime object
                dbCommand7.Parameters.AddWithValue("@ID", deleteShowtime.ID);

                //  Prepare parameters to query in DB
                dbCommand7.Prepare();

                //  Result of rows affected
                queryResult2 = dbCommand7.ExecuteNonQuery();

                //  Close DB connection
                dbConnection.Close();

                return queryResult;
            }
            catch
            {
                //  Error message
                Console.WriteLine("Error deleting showtime.");

                //  Open and close connection upon an error
                MySqlConnection dbConnection6 = CreateDBConnection();

                dbConnection6.Close();

                return 0;
            }
        }

        public int ModifyMovieDB(Movie addMovie)
        {
            try
            {
                //  Open DB connection
                dbConnection.Open();

                //  Declare int variables for rows affected upon changes
                int queryResult;

                //  SQL query to execute in the db           
                string sqlQuery = "UPDATE movie SET title = @Title, year = @Year, length = @Length, audience_rating = @Rating, image_file_path = @ImagePath WHERE id = @ID;";

                //  SQL containing the query to be executed
                MySqlCommand dbCommand11 = new MySqlCommand(sqlQuery, dbConnection);

                //  Associate parameters with movie objects
                dbCommand11.Parameters.AddWithValue("@ID", addMovie.ID);
                dbCommand11.Parameters.AddWithValue("@Title", addMovie.Title);
                dbCommand11.Parameters.AddWithValue("@Year", addMovie.Year);
                dbCommand11.Parameters.AddWithValue("@Length", addMovie.Length);
                dbCommand11.Parameters.AddWithValue("@Rating", addMovie.Rating);
                dbCommand11.Parameters.AddWithValue("@ImagePath", addMovie.ImagePath);

                //  Prepare parameters to query in DB
                dbCommand11.Prepare();

                //  Result of rows affected
                queryResult = dbCommand11.ExecuteNonQuery();

                //  Close DB connection
                dbConnection.Close();

                return queryResult;
            }
            catch
            {
                //  Error message
                Console.WriteLine("Error modifying movie.");

                //  Open and close connection upon an error
                MySqlConnection dbConnection8 = CreateDBConnection();

                dbConnection8.Close();

                return 0;
            }
        }

        public int CreateETicketDB(ETicket newTicket)
        {
            //  Open DB connection
            dbConnection.Open();

            //  Declare int variables for rows affected upon changes
            int queryResult;

            //  SQL query to execute in the db
            string sqlQuery = "INSERT INTO e_ticket VALUES(@ID, @PurchaseDate, @Showtime, @UserID);";

            //  SQL containing the query to be executed
            MySqlCommand dbCommand12 = new MySqlCommand(sqlQuery, dbConnection);

            //  Associate parameters with ticket objects
            dbCommand12.Parameters.AddWithValue("@ID", newTicket.ID);
            dbCommand12.Parameters.AddWithValue("@PurchaseDate", Convert.ToDateTime(newTicket.PurchaseDate).ToString("yyyy-MM-dd HH:mm:ss"));
            dbCommand12.Parameters.AddWithValue("@Showtime", newTicket.ShowtimeID);
            dbCommand12.Parameters.AddWithValue("@UserID", newTicket.UserID);

            //  Prepare parameters to query in DB
            dbCommand12.Prepare();

            //  Result of rows affected
            queryResult = dbCommand12.ExecuteNonQuery();

            //  Close DB connection
            dbConnection.Close();

            return queryResult;
        }
    }
}
