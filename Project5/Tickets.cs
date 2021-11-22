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
    public partial class Tickets : Form
    {
        public Tickets()
        {
            InitializeComponent();

            //             == FORMAT ==
            //  To change the format you must edit the const strings at the top of the DBManager.cs file
            //  This method sets up a connection to a MySQL database
            dbManager.SetDBConnection();
            // =======================================================

            //  Read data methods
            ReadMovieDB();
            ReadShowtimeDB();
        }

        //  Declare class instance for SQL connection methods
        DBManager dbManager = new DBManager();

        //  Declare lists
        List<Movie> movieList = new List<Movie>();
        List<Showtime> showtimeList = new List<Showtime>();

        private List<Showtime> ReadShowtimeDB()
        {
            //  Declare showtime
            Showtime readShowtime;

            //  Open DB connection
            dbManager.dbConnection.Open();

            //  SQL query to execute in the db
            string sqlQuery = "SELECT * FROM showtime;";

            //  SQL containing the query to be executed
            MySqlCommand dbCommand2 = new MySqlCommand(sqlQuery, dbManager.dbConnection);

            //  SQL query sent to the database
            MySqlDataReader dataReader2 = dbCommand2.ExecuteReader();

            //  Read all data entries
            while (dataReader2.Read())
            {
                //  Declare showtime
                readShowtime = new Showtime();

                //  Associate variables with read data
                readShowtime.ID = dataReader2.GetInt32(0);
                readShowtime.Time = dataReader2.GetDateTime(1);
                readShowtime.MovieID = dataReader2.GetInt32(2);
                readShowtime.RoomCode = dataReader2.GetString(3);
                readShowtime.TicketPrice = dataReader2.GetFloat(4);

                //  Add to list
                showtimeList.Add(readShowtime);

            }
            //  Close DB connection
            dbManager.dbConnection.Close();

            return showtimeList;
        }

        private List<Movie> ReadMovieDB()
        {
            //  Declare movie
            Movie readMovie;

            //  Open DB connection
            dbManager.dbConnection.Open();

            //  SQL query to execute in the db
            string sqlQuery = "SELECT * FROM movie;";

            //  SQL containing the query to be executed
            MySqlCommand dbCommand = new MySqlCommand(sqlQuery, dbManager.dbConnection);

            //  SQL query sent to the database
            MySqlDataReader dataReader = dbCommand.ExecuteReader();

            //  Read all data entries
            while (dataReader.Read())
            {
                //  Declare movie
                readMovie = new Movie();

                //  Associate variables with read data
                readMovie.ID = dataReader.GetInt32(0);
                readMovie.Title = dataReader.GetString(1);
                readMovie.Year = dataReader.GetInt32(2);
                readMovie.Length = dataReader.GetInt32(3);
                readMovie.Rating = dataReader.GetDouble(4);
                readMovie.ImagePath = dataReader.GetString(5);

                //  Load showtimes from movie according to the ID
                readMovie.Showtime = LoadShowtime(readMovie.ID);

                //  Add to list
                movieList.Add(readMovie);

                //  Add to ListBox
                moviesListBox.Items.Add(readMovie.Title);
            }
            //  Close DB connection
            dbManager.dbConnection.Close();

            return movieList;
        }

        private List<Showtime> LoadShowtime(int movieID)
        {
            //  The following objects will be used to access the jt_genre_movie table
            MySqlConnection dbConnection3 = dbManager.CreateDBConnection();
            MySqlCommand dbCommand3;
            MySqlDataReader dataReader3;

            //  Declare showtime
            Showtime readShowtime;

            //  Declare new showtimes list
            List<Showtime> foundShowtimes = new List<Showtime>();

            //  Open DB connection
            dbConnection3.Open();

            //  SQL query to execute in the db
            string sqlQuery = "SELECT * FROM showtime WHERE movie_id = " + movieID + ";";

            //  SQL containing the query to be executed
            dbCommand3 = new MySqlCommand(sqlQuery, dbConnection3);

            //  SQL query sent to the database
            dataReader3 = dbCommand3.ExecuteReader();

            //  Read all data entries
            while (dataReader3.Read())
            {
                //  Declare showtime
                readShowtime = new Showtime();

                //  Associate variables with read data
                readShowtime.ID = dataReader3.GetInt32(0);
                readShowtime.Time = dataReader3.GetDateTime(1);
                readShowtime.MovieID = dataReader3.GetInt32(2);
                readShowtime.RoomCode = dataReader3.GetString(3);
                readShowtime.TicketPrice = dataReader3.GetFloat(4);

                //  Add to list
                foundShowtimes.Add(readShowtime);
            }
            //  Close DB connection
            dbConnection3.Close();

            return foundShowtimes;
        }

        private int MovieData(string movieTitle)
        {
            //  Declare counter for loop
            int counter = 0;

            //  Loop to read each movie found in the list
            foreach (Movie readMovie in movieList)
            {
                if (movieTitle != movieList[counter].Title)
                {
                    //  Increment by +1
                    counter++;
                }
            }
            return counter;
        }

        private void Tickets_Load(object sender, EventArgs e)
        {

        }

        private void MoviesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Clear events
            showtimesListBox.Items.Clear();
            ticketTextBox.Clear();

            // if a ListBox item is not selected
            if (moviesListBox.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Select a movie.");
            }
            //  Otherwise
            else
            {
                //  Set int variable to selected ListBox item in array (#0)
                int index = moviesListBox.SelectedIndices[0];

                //  String selected ListView item (movie title) as text
                string title = moviesListBox.Items[index].ToString();

                //  For each showtime that exists under a single movie, add it to the showtimesListBox
                foreach (Showtime foundShowtime in movieList[MovieData(title)].Showtime)
                {
                    //  Add to ListBox in DateTime format YYYY-MM-DD HH:MM AM/PM
                    showtimesListBox.Items.Add(Convert.ToDateTime(foundShowtime.Time).ToString("yyyy-MM-dd HH:mm tt"));
                }
            }
        }

        private void ShowtimesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Open DB connection
            dbManager.dbConnection.Open();

            //  SQL query to execute in the database
            string sqlQuery = "SELECT COUNT(*) FROM e_ticket WHERE showtime_id = " + movieList[moviesListBox.SelectedIndex].Showtime[showtimesListBox.SelectedIndex].ID + ";";

            //  This is the actual SQL containing the query to be executed.
            MySqlCommand dbCommand = new MySqlCommand(sqlQuery, dbManager.dbConnection);

            //  Read ticket count
            int ticketCount = Convert.ToInt32(dbCommand.ExecuteScalar());

            //  Show amount of tickets sold
            ticketTextBox.Text = ticketCount.ToString();

            //  Close DB connection
            dbManager.dbConnection.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //  Closes the form
            this.Close();
        }
    }
}
