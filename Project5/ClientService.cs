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
    public partial class ClientService : Form
    {
        public ClientService()
        {
            InitializeComponent();

            //             == FORMAT ==
            //  To change the format you must edit the const strings at the top of the DBManager.cs file
            //  This method sets up a connection to a MySQL database
            dbManager.SetDBConnection();
            // =======================================================

            //  Read data methods
            ReadMoviesDB();
            ReadShowtimeDB();
        }

        //  Assign string variables to associate selected indexes and list objects in order to insert ETicket data
        public static DateTime purchaseTime;
        public static string movieTitle;
        public static string roomCode;
        public static string showtimeID;

        //  Declare lists
        private List<Movie> movieList = new List<Movie>();
        private List<Showtime> showtimeList = new List<Showtime>();

        //  Declare class instance for SQL connection methods
        DBManager dbManager = new DBManager();

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

        private void DisplayMovies()
        {
            //  Count for every object that exists in Movies list
            for (int i = 0; i < movieList.Count; i++)
            {
                //  Create LVI and populate ListView
                ListViewItem lvi = new ListViewItem();
                lvi.Text = movieList[i].Title;

                //  Add object to ListView
                movieListView.Items.Add(lvi);
            }
        }

        private List<Movie> ReadMoviesDB()
        {
            //  Clear ListView
            movieListView.Items.Clear();

            //  Clear movie list
            movieList.Clear();

            //  Declare movie
            Movie readMovie;

            //  Open DB connection
            dbManager.dbConnection.Open();

            // SQL query to execute in the db.
            string sqlQuery = "SELECT * FROM movie;";

            //  SQL containing the query to be executed
            MySqlCommand dbCommand = new MySqlCommand(sqlQuery, dbManager.dbConnection);

            //  Stores the result of the SQL query sent to the database
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
                readMovie.Showtime = LoadShowtime(readMovie.ID);

                //  If the image path is empty, declare string to make instance not null
                if (dataReader.GetString(5) == "")
                {
                    readMovie.ImagePath = @"images\noimage.jpg";
                    movieImageList.Images.Add(Image.FromFile(readMovie.ImagePath.ToString()));
                    movieList.Add(readMovie);
                }
                //  Otherwise read data for image and add to imageList + movie list
                else
                {
                    readMovie.ImagePath = dataReader.GetString(5);
                    movieImageList.Images.Add(Image.FromFile(readMovie.ImagePath.ToString()));
                    movieList.Add(readMovie);
                }
            }
            //  Close DB connection
            dbManager.dbConnection.Close();

            //  Method to display ListView movie items
            DisplayMovies();

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

        private void PurchaseTicketButton_Click(object sender, EventArgs e)
        {
            //  if a ListBox item is not selected
            if (showtimesListBox.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Select a showtime (if there are any available) first.");
            }
            else
            {

                //  Declare form
                TicketPurchase ticketPurchaseForm = new TicketPurchase();

                //  Show new form
                ticketPurchaseForm.ShowDialog();

                //  Declare random variable for ID
                Random rand = new Random();
                int idNum = rand.Next(1, 50000);

                //  Declare eticket variable
                ETicket NewTicket = new ETicket();

                //  Associate variables from the following:
                NewTicket.ID = int.Parse(idNum.ToString());     //  Random number generator
                NewTicket.PurchaseDate = DateTime.Now;          //  DateTime from the moment purchased
                NewTicket.ShowtimeID = int.Parse(showtimeID);   //  ShowtimeID from the SelectedIndex of its ListBox
                NewTicket.UserID = ClientLogin.userID;          //  UserID matched by username and password from the ClientLogin form

                //  Call method to create new ETicket
                dbManager.CreateETicketDB(NewTicket);
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //  Closes the form
            this.Close();
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

        private void ShowtimesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  if a ListBox item is not selected
            if (showtimesListBox.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Select a showtime.");
            }
            //  Otherwise
            else
            {
                //  Set int variable to selected ListView item in array (#0)
                int index = movieListView.SelectedIndices[0];

                //  String selected ListView item (movie title) as text
                string title = movieListView.Items[index].Text;

                //  For each showtime that exists under a single movie, add it to the showtimesListBox
                foreach (Showtime ShowTime in movieList[MovieData(title)].Showtime)
                {
                    //  If the movie ID in the list matches the showtime movie ID
                    if (movieList[MovieData(title)].ID == ShowTime.MovieID)
                    {
                        //  Declare purchase time through lists/selected indexes/indices
                        purchaseTime = movieList[movieListView.SelectedIndices[0]].Showtime[showtimesListBox.SelectedIndex].Time;

                        //  Declare room code by what is selected in the ListBox for its showtime
                        roomCode = ShowTime.RoomCode;

                        //  If there is more than one showtime, associate its ID by the selected index
                        showtimeID = ShowTime.ID.ToString();
                    }
                }
            }
        }

        private void ClientService_Load(object sender, EventArgs e)
        {
            //  Formatting for ListView column
            ColumnHeader titleColumn = new ColumnHeader();
            titleColumn.Text = "Title";
            titleColumn.Width = 300;
            movieListView.Columns.Add(titleColumn);
            movieListView.View = View.Details;
        }

        private void MovieListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Clear ListBox
            showtimesListBox.Items.Clear();

            //  If an item is selected
            if (movieListView.SelectedItems.Count > 0)
            {
                //  Set int variable to selected ListView item in array (#0)
                int intselectedindex = movieListView.SelectedIndices[0];

                //  String selected ListView item (movie title) as text
                string text = movieListView.Items[intselectedindex].Text;

                movieTitle = movieList[MovieData(text)].Title;

                //  Find image index for movieList to affiliate the correct image with the selected movie
                int imageIndex = movieList.FindIndex(a => a.Title == text);
                moviePictureBox.Image = movieImageList.Images[imageIndex];

                //  For each showtime that exists under a single movie, add it to the showtimesListBox
                foreach (Showtime foundShowtime in movieList[MovieData(text)].Showtime)
                {
                    //  Display showtime and ticket price
                    showtimesListBox.Items.Add(foundShowtime.Time + "\t" + foundShowtime.TicketPrice.ToString("C2"));
                }
            }
        }
    }
}
