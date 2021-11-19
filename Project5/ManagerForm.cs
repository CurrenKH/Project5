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
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();

            //             == FORMAT ==
            //  ( host_name, username, password, db_name )
            //  This method sets up a connection to a MySQL database
            dbManager.SetDBConnection("127.0.0.1", "CurrenH", "dfcg22r", "project");
            // =======================================================

            //  Read data methods
            ReadMoviesDB();
            ReadGenresDB();
            ReadScreeningRoomsDB();
            ReadShowtimesDB();
            ReadShowtimeMovieDB();
            ReadShowtimeScreeningRoomDB();
        }

        //  Constants to use when creating connections to the database
        public const string dbHost = "127.0.0.1";
        public const string dbUsername = "CurrenH";
        public const string dbPassword = "dfcg22r";
        public const string dbName = "project";

        //  Declare class instance for SQL connection methods
        DBManager dbManager = new DBManager();

        //  Declare MySQL instance for connections
        //MySqlConnection dbConnection;

        //  Declare lists
        private List<Movie> movieList = new List<Movie>();
        private List<Genre> genreList = new List<Genre>();
        private List<Showtime> showtimeList = new List<Showtime>();
        private List<ScreeningRoom> screeningRoomList = new List<ScreeningRoom>();

        private void TicketPortalButton_Click(object sender, EventArgs e)
        {
            //  Declare form
            Tickets ticketPortal = new Tickets();

            //  Show new form
            ticketPortal.ShowDialog(this);
        }

        private void ClientPortalButton_Click(object sender, EventArgs e)
        {
            //  Declare form
            Clients clientPortal = new Clients();

            //  Show new form
            clientPortal.ShowDialog(this);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //  Close the form
            this.Close();
        }

        private void FormatListView()
        {
            //  Formatting for all ListView columns
            ColumnHeader titleColumn = new ColumnHeader();
            titleColumn.Text = "Title";
            titleColumn.Width = 200;
            moviesListView.Columns.Add(titleColumn);
            moviesListView.View = View.Details;

            ColumnHeader yearColumn = new ColumnHeader();
            yearColumn.Text = "Year";
            yearColumn.Width = 80;
            moviesListView.Columns.Add(yearColumn);
        }

        private void DisplayMovies()
        {
            //  Count for every object that exists in Movies list
            for (int i = 0; i < movieList.Count; i++)
            {
                //  Create LVI and populate ListView
                ListViewItem lvi = new ListViewItem();
                lvi.Text = movieList[i].Title;
                lvi.SubItems.Add(movieList[i].Year.ToString());

                //  Add object to ListView
                moviesListView.Items.Add(lvi);
            }
        }

        private List<Movie> ReadMoviesDB()
        {

            //  Clear ListView
            moviesListView.Items.Clear();

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
                readMovie.Genres = LoadMovieGenres(readMovie.ID);
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
                //  Add to list
                //  Movies.Add(readMovie);
            }
            //  Close DB connection
            dbManager.dbConnection.Close();

            //  Method to display ListView movie items
            DisplayMovies();

            return movieList;
        }

        private List<Genre> ReadGenresDB()
        {
            //  Declare genre
            Genre readGenre;

            //  Open DB connection
            dbManager.dbConnection.Open();

            //  SQL query to execute in the db.
            string sqlQuery = "SELECT * FROM genre;";

            //  SQL containing the query to be executed
            MySqlCommand dbCommand = new MySqlCommand(sqlQuery, dbManager.dbConnection);

            //  Stores the result of the SQL query sent to the database
            MySqlDataReader dataReader = dbCommand.ExecuteReader();

            //  Read all data entries
            while (dataReader.Read())
            {
                //  Declare genre
                readGenre = new Genre();

                //  Associate variables with read data
                readGenre.Code = dataReader.GetString(0);
                readGenre.Name = dataReader.GetString(1);
                readGenre.Description = dataReader.GetString(2);

                //  Add to list
                genreList.Add(readGenre);

                //  Add to ComboBox
                addMovieGenreComboBox.Items.Add(readGenre.Name);

            }
            //  Close DB connection
            dbManager.dbConnection.Close();

            return genreList;
        }

        private List<Genre> LoadMovieGenres(int movieID)
        {
            //  The following objects will be used to access the jt_genre_movie table
            MySqlConnection dbConnection2 = dbManager.CreateDBConnection(dbHost, dbUsername, dbPassword, dbName);
            MySqlCommand dbCommand2;
            MySqlDataReader dataReader2;

            //  The following objects will be used to access the genre table
            MySqlConnection dbConnection3 = dbManager.CreateDBConnection(dbHost, dbUsername, dbPassword, dbName);
            MySqlCommand dbCommand3;
            MySqlDataReader dataReader3;

            string readGenreCode;

            //  Declare genre
            Genre readGenre;

            //  Declare new genre list
            List<Genre> foundGenres = new List<Genre>();

            //  Open DB connection
            dbConnection2.Open();

            //  SQL query to execute in the db
            string sqlQuery = "SELECT genre_code FROM jt_genre_movie WHERE movie_id = " + movieID + ";";

            //  SQL containing the query to be executed
            dbCommand2 = new MySqlCommand(sqlQuery, dbConnection2);

            //  SQL query sent to the database
            dataReader2 = dbCommand2.ExecuteReader();

            //  Read all data entries
            while (dataReader2.Read())
            {
                //  Declare genre
                readGenre = new Genre();

                //  Associate genre code to read data from DB
                readGenreCode = dataReader2.GetString(0);

                //  Open DB connection to genre table
                dbConnection3.Open();

                //  SQL query to execute in the db
                sqlQuery = "SELECT * FROM genre WHERE code = '" + readGenreCode + "';";

                //  SQL containing the query to be executed
                dbCommand3 = new MySqlCommand(sqlQuery, dbConnection3);

                //  SQL query sent to the database
                dataReader3 = dbCommand3.ExecuteReader();

                //  Read genre table
                dataReader3.Read();

                //  Associate variables with read data
                readGenre.Code = dataReader3.GetString(0);
                readGenre.Name = dataReader3.GetString(1);

                //  If the description is classified as null, insert empty string
                if (dataReader3.IsDBNull(2))
                {
                    readGenre.Description = "";
                }
                //  Otherwise continue to retrieve string value for description
                else
                {
                    readGenre.Description = dataReader3.GetString(2);
                }
                //  Add to list
                foundGenres.Add(readGenre);

                //  Close DB connection
                dbConnection3.Close();
            }
            //  Close DB connection
            dbConnection2.Close();

            return foundGenres;
        }

        private List<Showtime> LoadShowtime(int movieID)
        {
            //The following Connection, Command and DataReader objects will be used to access the jt_genre_movie table
            MySqlConnection dbConnection4 = dbManager.CreateDBConnection(dbHost, dbUsername, dbPassword, dbName);
            MySqlCommand dbCommand4;
            MySqlDataReader dataReader4;

            //  Declare showtime
            Showtime readShowtime;

            //  Declare new showtimes list
            List<Showtime> foundShowtimes = new List<Showtime>();

            //  Open DB connection
            dbConnection4.Open();

            //  SQL query to execute in the db
            string sqlQuery = "SELECT * FROM showtime WHERE movie_id = " + movieID + ";";

            //  SQL containing the query to be executed
            dbCommand4 = new MySqlCommand(sqlQuery, dbConnection4);

            //  SQL query sent to the database
            dataReader4 = dbCommand4.ExecuteReader();

            //  Read all data entries
            while (dataReader4.Read())
            {
                //  Declare showtime
                readShowtime = new Showtime();

                //  Associate variables with read data
                readShowtime.ID = dataReader4.GetInt32(0);
                readShowtime.Time = dataReader4.GetDateTime(1);
                readShowtime.MovieID = dataReader4.GetInt32(2);
                readShowtime.RoomCode = dataReader4.GetString(3);
                readShowtime.TicketPrice = dataReader4.GetFloat(4);

                //  Add to list
                foundShowtimes.Add(readShowtime);
            }
            //  Close DB connection
            dbConnection4.Close();

            return foundShowtimes;
        }

        private List<ScreeningRoom> ReadScreeningRoomsDB()
        {
            //  Declare screening room
            ScreeningRoom readScreeningRoom;

            //  Open DB connection
            dbManager.dbConnection.Open();

            //  SQL query to execute in the db
            string sqlQuery = "SELECT * FROM screening_room;";

            //  SQL containing the query to be executed
            MySqlCommand dbCommand5 = new MySqlCommand(sqlQuery, dbManager.dbConnection);

            //  SQL query sent to the database
            MySqlDataReader dataReader5 = dbCommand5.ExecuteReader();

            //  Read all data entries
            while (dataReader5.Read())
            {
                //  Declare screening room
                readScreeningRoom = new ScreeningRoom();

                //  Associate variables with read data
                readScreeningRoom.Code = dataReader5.GetString(0);
                readScreeningRoom.Capacity = dataReader5.GetInt32(1);

                //  If the description is classified as null, insert empty string
                if (dataReader5.IsDBNull(2))
                {
                    readScreeningRoom.Description = "";
                }
                //  Otherwise continue to retrieve string value for description
                else
                {
                    readScreeningRoom.Description = dataReader5.GetString(2);
                }

                //  Add to ListBox
                screeningRoomsListBox.Items.Add(readScreeningRoom.Code);

                //  Add to list
                screeningRoomList.Add(readScreeningRoom);

            }
            //  Close DB connection
            dbManager.dbConnection.Close();

            return screeningRoomList;
        }


        private List<Movie> ReadShowtimeMovieDB()
        {
            //  Declare movie
            Movie readMovie;

            //  Open DB connection
            dbManager.dbConnection.Open();

            //  SQL query to execute in the db
            string sqlQuery = "SELECT * FROM movie;";

            //  SQL containing the query to be executed
            MySqlCommand dbCommand6 = new MySqlCommand(sqlQuery, dbManager.dbConnection);

            //  SQL query sent to the database
            MySqlDataReader dataReader6 = dbCommand6.ExecuteReader();

            //  Read all data entries
            while (dataReader6.Read())
            {
                //  Declare movie
                readMovie = new Movie();

                //  Associate variables with read data
                readMovie.ID = dataReader6.GetInt32(0);
                readMovie.Title = dataReader6.GetString(1);
                readMovie.Year = dataReader6.GetInt32(2);
                readMovie.Length = dataReader6.GetInt32(3);
                readMovie.Rating = dataReader6.GetDouble(4);

                //  Add to list
                movieList.Add(readMovie);

                //  Add to ComboBox
                showtimeMovieComboBox.Items.Add(readMovie.Title);

            }
            //  Close DB connection
            dbManager.dbConnection.Close();

            return movieList;
        }

        private List<ScreeningRoom> ReadShowtimeScreeningRoomDB()
        {
            //  Declare screening room
            ScreeningRoom readScreeningRoom;

            //  Open DB connection
            dbManager.dbConnection.Open();

            //  SQL query to execute in the db
            string sqlQuery = "SELECT * FROM screening_room;";

            //  SQL containing the query to be executed
            MySqlCommand dbCommand7 = new MySqlCommand(sqlQuery, dbManager.dbConnection);

            //  SQL query sent to the database
            MySqlDataReader dataReader7 = dbCommand7.ExecuteReader();

            //  Read all data entries
            while (dataReader7.Read())
            {
                //  Declare screening room
                readScreeningRoom = new ScreeningRoom();

                //  Associate variables with read data
                readScreeningRoom.Code = dataReader7.GetString(0);
                readScreeningRoom.Capacity = dataReader7.GetInt32(1);

                //  Add to list
                screeningRoomList.Add(readScreeningRoom);
                
                //  Add to ComboBoxes
                showtimeRoomComboBox.Items.Add(readScreeningRoom.Code);
                addShowtimeRoomComboBox.Items.Add(readScreeningRoom.Code);

            }
            //  Close DB connection
            dbManager.dbConnection.Close();

            return screeningRoomList;
        }


        private List<Showtime> ReadShowtimesDB()
        {
            //  Declare showtime
            Showtime readShowtime;

            //  Open DB connection
            dbManager.dbConnection.Open();

            //  SQL query to execute in the db
            string sqlQuery = "SELECT * FROM showtime;";

            //  SQL containing the query to be executed
            MySqlCommand dbCommand8 = new MySqlCommand(sqlQuery, dbManager.dbConnection);

            //  SQL query sent to the database
            MySqlDataReader dataReader8 = dbCommand8.ExecuteReader();

            //  Read all data entries
            while (dataReader8.Read())
            {
                //  Declare showtime
                readShowtime = new Showtime();

                //  Associate variables with read data
                readShowtime.ID = dataReader8.GetInt32(0);
                readShowtime.Time = dataReader8.GetDateTime(1);
                readShowtime.MovieID = dataReader8.GetInt32(2);
                readShowtime.RoomCode = dataReader8.GetString(3);
                readShowtime.TicketPrice = dataReader8.GetFloat(4);
                readShowtime.Movie = LoadMovie(readShowtime.MovieID);
                readShowtime.ScreeningRoom = LoadScreeningRoom(readShowtime.RoomCode);

                //  Add to list
                showtimeList.Add(readShowtime);

                //  Add to ListBox
                showtimesListBox.Items.Add(readShowtime.ID);
                

            }
            //  Close DB connection
            dbManager.dbConnection.Close();

            return showtimeList;
        }

        private List<Movie> LoadMovie(int movieID)
        {
            //  The following objects will be used to access the jt_genre_movie table
            MySqlConnection dbConnection9 = dbManager.CreateDBConnection(dbHost, dbUsername, dbPassword, dbName);
            MySqlCommand dbCommand9;
            MySqlDataReader dataReader9;

            //  Declare movie
            Movie readMovie;

            //  Declare new movies list
            List<Movie> foundMovies = new List<Movie>();

            //  Open DB connection
            dbConnection9.Open();

            //  SQL query to execute in the db
            string sqlQuery = "SELECT * FROM movie WHERE id = " + movieID + ";";

            //  SQL containing the query to be executed
            dbCommand9 = new MySqlCommand(sqlQuery, dbConnection9);

            //  SQL query sent to the database
            dataReader9 = dbCommand9.ExecuteReader();

            //  Read all data entries
            while (dataReader9.Read())
            {
                //  Declare movie
                readMovie = new Movie();

                //  Associate variables with read data
                readMovie.ID = dataReader9.GetInt32(0);
                readMovie.Title = dataReader9.GetString(1);
                readMovie.Year = dataReader9.GetInt32(2);
                readMovie.Length = dataReader9.GetInt32(3);
                readMovie.Rating = dataReader9.GetDouble(4);

                //  Add to list
                foundMovies.Add(readMovie);
            }
            //  Close DB connection
            dbConnection9.Close();

            return foundMovies;
        }

        private List<ScreeningRoom> LoadScreeningRoom(string roomCode)
        {
            //  The following objects will be used to access the jt_genre_movie table
            MySqlConnection dbConnection10 = dbManager.CreateDBConnection(dbHost, dbUsername, dbPassword, dbName);
            MySqlCommand dbCommand10;
            MySqlDataReader dataReader10;

            //  Declare screening room
            ScreeningRoom readScreeningRoom;

            //  Declare new screening room list
            List<ScreeningRoom> foundScreeningRooms = new List<ScreeningRoom>();

            //  Open DB connection
            dbConnection10.Open();

            //  SQL query to execute in the db
            string sqlQuery = "SELECT * FROM screening_room WHERE code = '" + roomCode + "';";

            //  SQL containing the query to be executed
            dbCommand10 = new MySqlCommand(sqlQuery, dbConnection10);

            //  SQL query sent to the database
            dataReader10 = dbCommand10.ExecuteReader();

            //  Read all data entries
            while (dataReader10.Read())
            {
                //  Declare screening room
                readScreeningRoom = new ScreeningRoom();

                //  Associate variables with read data
                readScreeningRoom.Code = dataReader10.GetString(0);
                readScreeningRoom.Capacity = dataReader10.GetInt32(1);

                //  If the description is classified as null, insert empty string
                if (dataReader10.IsDBNull(2))
                {
                    readScreeningRoom.Description = "";
                }
                //  Otherwise continue to retrieve string value for description
                else
                {
                    readScreeningRoom.Description = dataReader10.GetString(2);
                }

                //  Add to list
                foundScreeningRooms.Add(readScreeningRoom);
            }
            //  Close DB connection
            dbConnection10.Close();

            return foundScreeningRooms;
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

        private int ShowtimeData(string movieTitle)
        {
            //  Declare counter for loop
            int counter = 0;

            //  Loop to read each showtime found in the list
            foreach (Showtime readShowtime in showtimeList)
            {
                if (movieTitle != showtimeList[counter].ID.ToString())
                {
                    //  Increment by +1
                    counter++;
                }
            }
            return counter;
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            //  Format ListView upon loading form
            FormatListView();
        }

        private void MoviesListView_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //  If an item is selected
            if (moviesListView.SelectedItems.Count > 0)
            {

                //  Set int variable to selected ListView item in array (#0)
                int intselectedindex = moviesListView.SelectedIndices[0];

                //  String selected ListView item (movie title) as text
                string title = moviesListView.Items[intselectedindex].Text;

                //  Fields to display information by the movie list item via loop method -> title
                idTextBox.Text = movieList[MovieData(title)].ID.ToString();
                titleTextBox.Text = movieList[MovieData(title)].Title;
                yearTextBox.Text = movieList[MovieData(title)].Year.ToString();
                lengthTextBox.Text = movieList[MovieData(title)].Length.ToString();
                ratingTextBox.Text = movieList[MovieData(title)].Rating.ToString("N2");
                imagePathTextBox.Text = movieList[MovieData(title)].ImagePath;

                //  Find image index for movieList to affiliate the correct image with the selected movie
                int imageIndex = movieList.FindIndex(a => a.Title == title);
                moviePictureBox.Image = movieImageList.Images[imageIndex];

                //  Clear ListBox
                genreListBox.Items.Clear();

                //  For each genre that exists under a single movie, add it to the ListBox
                foreach (Genre foundGenre in movieList[MovieData(title)].Genres)
                {
                    //  Add genre names to ListBox
                    genreListBox.Items.Add(foundGenre.Name);
                }
            }
        }

        private void ScreeningRoomsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  if a ListBox item is not selected
            if (screeningRoomsListBox.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Select a screening room.");
            }
            //  Otherwise
            else
            {
                //  Set int variable to selected ListBox item in array (#0)
                int index = screeningRoomsListBox.SelectedIndices[0];

                //  Fields to display information by the screening room item
                screeningRoomCodeTextBox.Text = screeningRoomList[index].Code;
                screeningRoomCapacityTextBox.Text = screeningRoomList[index].Capacity.ToString();
                screeningRoomDescriptionTextBox.Text = screeningRoomList[index].Description;
            }
        }

        private void ShowtimesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            // if a ListBox item is not selected
            if (showtimesListBox.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Select a showtime.");
            }
            //  Otherwise
            else
            {
                //  Set int variable to selected ListBox item in array (#0)
                int index = showtimesListBox.SelectedIndices[0];

                //  Declare selected index item as a string
                string showName = showtimesListBox.Items[index].ToString();

                foreach (ScreeningRoom selectedScreeningRoom in showtimeList[ShowtimeData(showName)].ScreeningRoom)
                {
                    //  Associate showtime code from selected showtime to ComboBox
                    showtimeRoomComboBox.Text = selectedScreeningRoom.Code;
                }

                foreach (Movie selectedMovie in showtimeList[ShowtimeData(showName)].Movie)
                {
                    //  Associate showtime movie from selected showtime to ComboBox
                    showtimeMovieComboBox.Text = selectedMovie.Title;
                }

                //  Fields to display information by the showtime item
                showtimeIDTextBox.Text = showtimeList[ShowtimeData(showName)].ID.ToString();
                showtimeDateTextBox.Text = showtimeList[ShowtimeData(showName)].Time.ToString();
                showtimeCostTextBox.Text = showtimeList[ShowtimeData(showName)].TicketPrice.ToString();
            }
        }
    }
}
