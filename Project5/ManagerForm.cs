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
using System.Text.RegularExpressions;

namespace Project5
{
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();

            //             == FORMAT ==
            //  To change the format you must edit the const strings at the top of the DBManager.cs file
            //  This method sets up a connection to a MySQL database
            dbManager.SetDBConnection();
            // =======================================================

            //  Read data methods
            ReadMoviesDB();
            ReadGenresDB();
            ReadScreeningRoomsDB();
            ReadShowtimesDB();
            ReadShowtimeMovieDB();
            ReadShowtimeScreeningRoomDB();
        }

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
            MySqlConnection dbConnection2 = dbManager.CreateDBConnection();
            MySqlCommand dbCommand2;
            MySqlDataReader dataReader2;

            //  The following objects will be used to access the genre table
            MySqlConnection dbConnection3 = dbManager.CreateDBConnection();
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
            MySqlConnection dbConnection4 = dbManager.CreateDBConnection();
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
            //  Clear ListBox
            screeningRoomsListBox.Items.Clear();

            //  Clear screening room list
            screeningRoomList.Clear();

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

                //  Add to ComboBoxes
                showtimeMovieComboBox.Items.Add(readMovie.Title);
                addShowtimeMovieComboBox.Items.Add(readMovie.Title);

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
            MySqlConnection dbConnection9 = dbManager.CreateDBConnection();
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
            MySqlConnection dbConnection10 = dbManager.CreateDBConnection();
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

            //  Format for both DateTimePickers
            addShowtimeDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            addShowtimeDateTimePicker.Format = DateTimePickerFormat.Custom;

            showtimeDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            showtimeDateTimePicker.Format = DateTimePickerFormat.Custom;
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
                //  Format DateTimePicker
                showtimeDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
                showtimeDateTimePicker.Format = DateTimePickerFormat.Custom;

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
                showtimeDateTimePicker.Text = showtimeList[ShowtimeData(showName)].Time.ToString();
                showtimeCostTextBox.Text = showtimeList[ShowtimeData(showName)].TicketPrice.ToString();
            }
        }

        private void ClearMovieInputs()
        {
            // Clear TextBoxes
            idTextBox.Text = "";
            titleTextBox.Text = "";
            yearTextBox.Text = "";
            lengthTextBox.Text = "";
            ratingTextBox.Text = "";
            imagePathTextBox.Text = "";

            //  Clear ListBox
            genreListBox.Items.Clear();

            //  Clear pictureBox
            moviePictureBox.Image = null;
        }

        private void MovieSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            //  Search function for movie titles
            //  Source: https://stackoverflow.com/questions/20341113/search-listview-items-using-textbox
            if (movieSearchTextBox.Text != "")
            {
                for (int i = moviesListView.Items.Count - 1; i >= 0; i--)
                {
                    var item = moviesListView.Items[i];
                    if (item.Text.ToLower().Contains(movieSearchTextBox.Text.ToLower()))
                    {
                        //  item.BackColor = SystemColors.Highlight;
                        //  item.ForeColor = SystemColors.HighlightText;
                    }
                    else
                    {
                        moviesListView.Items.Remove(item);
                    }
                }
                if (moviesListView.SelectedItems.Count == 1)
                {
                    moviesListView.Focus();
                }

            }
            else
            {
                //  If the TextBox is empty revert ListView to default
                ReadMoviesDB();

                //  Remove movie data method
                ClearMovieInputs();
            }
        }

        private void ResetMovieSearchButton_Click(object sender, EventArgs e)
        {
            //  Empty search TextBox
            movieSearchTextBox.Text = "";

            //  If the TextBox is empty revert ListView to default
            ReadMoviesDB();

            //  Remove movie data method
            ClearMovieInputs();
        }

        private void ClearAddScreeningRoomInputs()
        {
            //  Clear TextBoxes
            addScreeningRoomCapacityTextBox.Text = "";
            addScreeningRoomDescriptionTextBox.Text = "";
        }

        private void ClearScreeningRoomInputs()
        {
            //  Clear TextBoxes
            screeningRoomCodeTextBox.Text = "";
            screeningRoomCapacityTextBox.Text = "";
            screeningRoomDescriptionTextBox.Text = "";
        }

        private void RefreshScreeningRooms()
        {
            //  Loop to repopulate ComboBoxes after a data change method is used
            for (int i = 0; i < screeningRoomList.Count; i++)
            {
                addShowtimeRoomComboBox.Items.Add(screeningRoomList[i].Code);
                showtimeRoomComboBox.Items.Add(screeningRoomList[i].Code);
            }
        }

        private void AddScreeningRoomButton_Click(object sender, EventArgs e)
        {
            //  Declare int variable for integer checking
            int num = -1;

            //  Create array of TextBoxes
            //  Source: https://stackoverflow.com/questions/29684210/most-efficient-way-to-see-if-any-of-textboxes-are-empty-c-sharp
            var textBoxCollection = new[] { addScreeningRoomCapacityTextBox, addScreeningRoomDescriptionTextBox };

            //  Declare boolean value to use for array
            bool atleastOneTextboxEmpty;

            //  Check if any TextBoxes are empty within the array
            if (atleastOneTextboxEmpty = textBoxCollection.Any(t => String.IsNullOrWhiteSpace(t.Text)))
            {
                //  Show error message
                MessageBox.Show("Not all entries for ADD SCREENING ROOM are filled.");
            }
            //  Integer checking for ID
            else if (!int.TryParse(addScreeningRoomCapacityTextBox.Text, out num))
            {
                //  Show error message
                MessageBox.Show("Invalid capacity input. Use an integer instead.");
            }
            else
            {
                //  Random code generator for 2 letters and 1 number
                //  Source: https://stackoverflow.com/questions/45106385/how-to-generate-random-string-of-numbers-and-letters-in-form-2-letters-4-num/45106818
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                var numbers = "0123456789";

                //  Maximum length of 3
                var stringChars = new char[3];
                var random = new Random();

                //  Generate 2 letters at random
                for (int i = 0; i < 2; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                //  Generate 1 number at random
                for (int i = 2; i < 3; i++)
                {
                    stringChars[i] = numbers[random.Next(numbers.Length)];
                }

                //  Return string result of ??#
                var finalString = new String(stringChars);

                //  Declare screening room
                ScreeningRoom addScreeningRoom = new ScreeningRoom();

                //  Associate variables with inputted data by the user
                addScreeningRoom.Code = finalString;
                addScreeningRoom.Capacity = int.Parse(addScreeningRoomCapacityTextBox.Text);
                addScreeningRoom.Description = addScreeningRoomDescriptionTextBox.Text;

                //  Clear screening room list
                screeningRoomList.Clear();

                //  Call method to insert add screening room fields from form to a screening room object in the list
                dbManager.AddScreeningRoomDB(addScreeningRoom);

                //  Clear ListBox
                screeningRoomsListBox.Items.Clear();

                //  Read screening rooms from the database
                ReadScreeningRoomsDB();

                //  Clear input method
                ClearAddScreeningRoomInputs();

                //  Clear ComboBoxes
                addShowtimeRoomComboBox.Items.Clear();
                showtimeRoomComboBox.Items.Clear();

                //  Update ComboBox for showtime (add screening room)
                RefreshScreeningRooms();
            }
        }

        private void DeleteScreeningRoomButton_Click(object sender, EventArgs e)
        {
            //  Check if a ListBox selection for a screening room exists
            if (screeningRoomsListBox.SelectedIndex < 0)
            {
                //  Show error message
                MessageBox.Show("Select a screening room from the ListBox.");
            }
            //  Otherwise continue actions
            else
            {
                //  Declare screening room
                ScreeningRoom deleteScreeningRoom = new ScreeningRoom();

                deleteScreeningRoom.Code = screeningRoomCodeTextBox.Text;
                deleteScreeningRoom.Capacity = int.Parse(screeningRoomCapacityTextBox.Text);
                deleteScreeningRoom.Description = screeningRoomDescriptionTextBox.Text;

                //  Clear screening room list
                screeningRoomList.Clear();

                //  Call method to delete screening room from the list according to the screening room fields read
                DeleteScreeningRoomDB(deleteScreeningRoom);

                //  Clear ListBox
                screeningRoomsListBox.Items.Clear();

                //  Read screening rooms from the database
                ReadScreeningRoomsDB();

                //  Clear inputs method
                ClearScreeningRoomInputs();

                //  Clear ComboBoxes
                addShowtimeRoomComboBox.Items.Clear();
                showtimeRoomComboBox.Items.Clear();

                //  Update ComboBox for showtime (add screening room)
                RefreshScreeningRooms();
            }
        }

        private void ModifyScreeningRoomButton_Click(object sender, EventArgs e)
        {
            //  Check if a ListBox selection for a screening room exists
            if (screeningRoomsListBox.SelectedIndex < 0)
            {
                //  Show error message
                MessageBox.Show("Select a screening room from the ListBox.");
            }
            //  Otherwise continue actions
            else
            {
                //  Enable TextBoxes and Button to allow access for changes made by the user
                screeningRoomCapacityTextBox.Enabled = true;
                screeningRoomDescriptionTextBox.Enabled = true;
                saveScreeningRoomButton.Enabled = true;
            }
        }

        private void SaveScreeningRoomButton_Click(object sender, EventArgs e)
        {
            //  Declare int variable for integer checking
            int num = -1;

            //  Create array of TextBoxes
            var textBoxCollection = new[] { screeningRoomCapacityTextBox, screeningRoomDescriptionTextBox };

            //  Declare boolean value to use for array
            bool atleastOneTextboxEmpty;

            //  Check if any TextBoxes are empty within the array
            if (atleastOneTextboxEmpty = textBoxCollection.Any(t => String.IsNullOrWhiteSpace(t.Text)))
            {
                //  Show error message
                MessageBox.Show("Not all entries for MODIFYING SCREENING ROOM are filled.");
            }
            //  Integer checking for ID
            else if (!int.TryParse(screeningRoomCapacityTextBox.Text, out num))
            {
                //  Show error message
                MessageBox.Show("Invalid capacity input. Use an integer instead.");
            }
            else
            {
                //  Declare screening room
                ScreeningRoom modifyScreeningRoom = new ScreeningRoom();

                //  Associate variables with inputted data by the user 
                modifyScreeningRoom.Code = screeningRoomCodeTextBox.Text;
                modifyScreeningRoom.Capacity = int.Parse(screeningRoomCapacityTextBox.Text);
                modifyScreeningRoom.Description = screeningRoomDescriptionTextBox.Text;

                //  Clear screening room list
                screeningRoomList.Clear();

                //  Call method to save screening room changes from the list according to the screening room fields read
                dbManager.ModifyScreeningRoomDB(modifyScreeningRoom);

                //  Clear ListBox
                screeningRoomsListBox.Items.Clear();

                //  Read screening rooms from the database
                ReadScreeningRoomsDB();

                //  Clear inputs method
                ClearScreeningRoomInputs();

                //  Disable TextBoxes and Buttons to deny access for anymore changes made by the user
                screeningRoomCapacityTextBox.Enabled = false;
                screeningRoomDescriptionTextBox.Enabled = false;
                saveScreeningRoomButton.Enabled = false;
            }
        }
        private int DeleteScreeningRoomDB(ScreeningRoom deleteScreeningRoom)
        {
            try
            {
                //  Open DB connection
                dbManager.dbConnection.Open();

                //  Declare int variable for rows affected upon changes
                int queryResult;


                //// -- In order to delete a screening room with a showtime already planned for that room you must first -- ////
                //// -- cancel the movie showing by deleting the showtime first then delete the screening room after-- ////


                //  SQL query to execute in the db
                string sqlQuery = "DELETE FROM screening_room WHERE code = @Code;";

                //  SQL containing the query to be executed
                MySqlCommand dbCommand4 = new MySqlCommand(sqlQuery, dbManager.dbConnection);

                //  Associate parameters with screening room objects
                dbCommand4.Parameters.AddWithValue("@Code", deleteScreeningRoom.Code);

                //  Prepare parameters to query in DB
                dbCommand4.Prepare();

                //  Result of rows affected
                queryResult = dbCommand4.ExecuteNonQuery();

                //  Close DB connection
                dbManager.dbConnection.Close();

                return queryResult;
            }
            catch
            {
                //  Error message
                MessageBox.Show("Error deleting screening room." +
                    " If you are attempting to delete a screening room with a movie showtime planned," +
                    " you must delete the showtimes associated with this room first and which *cancels* the event(s). " +
                    "Check showtimes in order to do this.");

                //  Open and close connection upon an error
                MySqlConnection dbConnection3 = dbManager.CreateDBConnection();

                dbConnection3.Close();

                return 0;
            }
        }

        private int AddShowtimeDB(Showtime addShowtime)
        {
            try
            {
                //  Open DB connection
                dbManager.dbConnection.Open();

                //  Declare int variable for rows affected upon changes
                int queryResult;

                //  SQL query to execute in the db
                string sqlQuery = "INSERT INTO showtime VALUES(@ID, @Time, @Movie, @Room, @Price);";

                //  SQL containing the query to be executed
                MySqlCommand dbCommand6 = new MySqlCommand(sqlQuery, dbManager.dbConnection);

                //  Associate parameters with screening room objects
                dbCommand6.Parameters.AddWithValue("@ID", addShowtime.ID);
                dbCommand6.Parameters.AddWithValue("@Time", Convert.ToDateTime(addShowtime.Time).ToString("yyyy-MM-dd HH:mm:ss"));
                dbCommand6.Parameters.AddWithValue("@Movie", movieList[addShowtimeMovieComboBox.SelectedIndex].ID);
                dbCommand6.Parameters.AddWithValue("@Room", addShowtime.RoomCode);
                dbCommand6.Parameters.AddWithValue("@Price", addShowtime.TicketPrice);

                //  Prepare parameters to query in DB
                dbCommand6.Prepare();

                //  Result of rows affected
                queryResult = dbCommand6.ExecuteNonQuery();

                //  Close DB connection
                dbManager.dbConnection.Close();

                return queryResult;
            }
            catch
            {
                //  Error message
                MessageBox.Show("Error adding showtime.");

                //  Open and close connection upon an error
                MySqlConnection dbConnection6 = dbManager.CreateDBConnection();

                dbConnection6.Close();

                return 0;
            }
        }

        private int ModifyShowtimeDB(Showtime modifyShowtime)
        {
            try
            {
                //  Open DB connection
                dbManager.dbConnection.Open();

                //  Declare int variable for rows affected upon changes
                int queryResult;

                //This is a string representing the SQL query to execute in the db           
                string sqlQuery = "UPDATE showtime SET date_time = @Time, s_room_code = @Room, ticket_price = @Price WHERE id = @ID;";

                //This is the actual SQL containing the query to be executed
                MySqlCommand dbCommand7 = new MySqlCommand(sqlQuery, dbManager.dbConnection);

                //  Associate parameters with screening room objects
                dbCommand7.Parameters.AddWithValue("@Time", Convert.ToDateTime(modifyShowtime.Time).ToString("yyyy-MM-dd HH:mm:ss"));
                dbCommand7.Parameters.AddWithValue("@Room", modifyShowtime.RoomCode);
                dbCommand7.Parameters.AddWithValue("@Price", modifyShowtime.TicketPrice);
                dbCommand7.Parameters.AddWithValue("@ID", modifyShowtime.ID);

                //  Prepare parameters to query in DB
                dbCommand7.Prepare();

                //  Result of rows affected
                queryResult = dbCommand7.ExecuteNonQuery();

                //  Close DB connection
                dbManager.dbConnection.Close();

                return queryResult;
            }
            catch
            {
                //  Error message
                MessageBox.Show("Error modifying showtime.");

                //  Open and close connection upon an error
                MySqlConnection dbConnection7 = dbManager.CreateDBConnection();

                dbConnection7.Close();

                return 0;
            }
        }

        private void addShowtimeButton_Click(object sender, EventArgs e)
        {
            //  Declare float variable for number checking
            float f;

            //  Create array of TextBoxes
            var textBoxCollection = new[] { addShowtimeMovieComboBox, addShowtimeRoomComboBox };

            //  Declare boolean value to use for array
            bool atleastOneTextboxEmpty;

            //  Check if any TextBoxes are empty within the array
            if (atleastOneTextboxEmpty = textBoxCollection.Any(t => String.IsNullOrWhiteSpace(t.Text)))
            {
                //  Show error message
                MessageBox.Show("Not all ComboBox entries for ADD SHOWTIME are filled.");
            }
            //  Check if ComboBox is empty
            else if (addShowtimeCostTextBox.Text == "")
            {
                //  Show error message
                MessageBox.Show("Choose a price for the showtime.");
            }
            //  Number checking for price
            else if (!float.TryParse(addShowtimeCostTextBox.Text, out f))
            {
                //  Show error message
                MessageBox.Show("Invalid price input. Use a number instead.");
            }
            else
            {
                //  Declare random variable for ID
                Random rand = new Random();
                int idNum = rand.Next(100, 50000);

                //  Declare showtime
                Showtime addShowtime = new Showtime();

                //  Associate variables with inputted data by the user
                addShowtime.ID = int.Parse(idNum.ToString());
                addShowtime.Time = DateTime.Parse(addShowtimeDateTimePicker.Text);
                addShowtime.RoomCode = addShowtimeRoomComboBox.Text;
                addShowtime.TicketPrice = float.Parse(addShowtimeCostTextBox.Text);

                //  Clear showtime list
                showtimeList.Clear();

                //  Call method to insert add showtime room fields from form to a showtime object in the list
                AddShowtimeDB(addShowtime);

                //  Clear ListBox
                showtimesListBox.Items.Clear();

                //  Read showtimes from the database
                ReadShowtimesDB();

                //  Method to clear showtime input data
                ClearAddShowtimeInputs();

                //  Read movies from the database
                ReadMoviesDB();

                //  Read screening rooms from the database
                ReadScreeningRoomsDB();

                //  Methods to refresh selections for ComboBoxes
                ReadAddShowtimeMovieComboBox();
                ReadAddShowtimeRoomComboBox();
            }
        }

        private void ReadAddShowtimeMovieComboBox()
        {
            //  Clear ComboBox
            addShowtimeMovieComboBox.Items.Clear();

            //  Loop to repopulate ComboBox after a clear data method is used
            for (int i = 0; i < movieList.Count; i++)
            {
                addShowtimeMovieComboBox.Items.Add(movieList[i].Title);
            }
        }

        private void ReadShowtimeMovieComboBox()
        {
            //  Clear ComboBox
            showtimeMovieComboBox.Items.Clear();

            //  Loop to repopulate ComboBox after a clear data method is used
            for (int i = 0; i < movieList.Count; i++)
            {
                showtimeMovieComboBox.Items.Add(movieList[i].Title);
            }
        }

        private void ReadAddShowtimeRoomComboBox()
        {
            //  Clear ComboBox
            addShowtimeRoomComboBox.Items.Clear();

            //  Loop to repopulate ComboBox after a clear data method is used
            for (int i = 0; i < screeningRoomList.Count; i++)
            {
                addShowtimeRoomComboBox.Items.Add(screeningRoomList[i].Code);
            }
        }

        private void ReadShowtimeRoomComboBox()
        {
            //  Clear ComboBox
            showtimeRoomComboBox.Items.Clear();

            //  Loop to repopulate ComboBox after a clear data method is used
            for (int i = 0; i < screeningRoomList.Count; i++)
            {
                showtimeRoomComboBox.Items.Add(screeningRoomList[i].Code);
            }
        }

        private void ClearShowtimeInputs()
        {
            //  Clear inputs
            showtimeIDTextBox.Text = "";
            showtimeMovieComboBox.Text = "";
            showtimeRoomComboBox.Text = "";
            showtimeCostTextBox.Text = "";

            //  Clear DateTimePicker
            //  Source: https://stackoverflow.com/questions/40378035/clear-the-datetimepicker-control-in-c-sharp-winfoms
            showtimeDateTimePicker.CustomFormat = " ";
            showtimeDateTimePicker.Format = DateTimePickerFormat.Custom;
        }

        private void ClearAddShowtimeInputs()
        {
            //  Clear inputs
            addShowtimeMovieComboBox.Text = "";
            addShowtimeRoomComboBox.Text = "";
            addShowtimeCostTextBox.Text = "";
        }

        private void modifyShowtimeButton_Click(object sender, EventArgs e)
        {
            //  Check if a ListBox selection for a showtime exists
            if (showtimesListBox.SelectedIndex < 0)
            {
                //  Show error message
                MessageBox.Show("Select a showtime from the ListBox.");
            }
            //  Otherwise continue actions
            else
            {
                //  Format DateTimePicker
                showtimeDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
                showtimeDateTimePicker.Format = DateTimePickerFormat.Custom;

                //  Enable TextBoxes and Button to allow access for changes made by the user
                showtimeDateTimePicker.Enabled = true;
                showtimeMovieComboBox.Enabled = true;
                showtimeRoomComboBox.Enabled = true;
                showtimeCostTextBox.Enabled = true;
                saveShowtimeButton.Enabled = true;
            }
        }

        private void saveShowtimeButton_Click(object sender, EventArgs e)
        {
            //  Declare float variable for number checking
            float f;

            //  Create array of TextBoxes
            var textBoxCollection = new[] { showtimeMovieComboBox, showtimeRoomComboBox };

            //  Declare boolean value to use for array
            bool atleastOneTextboxEmpty;

            //  Check if any TextBoxes are empty within the array
            if (atleastOneTextboxEmpty = textBoxCollection.Any(t => String.IsNullOrWhiteSpace(t.Text)))
            {
                //  Show error message
                MessageBox.Show("Not all ComboBox entries for MODIFYING SHOWTIME are filled.");
            }
            //  Check if ComboBox is empty
            else if (showtimeCostTextBox.Text == "")
            {
                //  Show error message
                MessageBox.Show("Choose a price for the showtime.");
            }
            //  Number checking for price
            else if (!float.TryParse(showtimeCostTextBox.Text, out f))
            {
                //  Show error message
                MessageBox.Show("Invalid price input. Use a number instead.");
            }
            else
            {
                //  Declare showtime
                Showtime modifyShowtime = new Showtime();

                //  Associate variables with inputted data by the user
                modifyShowtime.ID = int.Parse(showtimeIDTextBox.Text);
                modifyShowtime.Time = DateTime.Parse(showtimeDateTimePicker.Text);
                modifyShowtime.RoomCode = showtimeRoomComboBox.Text;
                modifyShowtime.TicketPrice = float.Parse(showtimeCostTextBox.Text);

                //  Clear showtime list
                showtimeList.Clear();

                //  Call method to save showtime changes from the list according to the showtime fields read
                ModifyShowtimeDB(modifyShowtime);

                //  Clear ListBox
                showtimesListBox.Items.Clear();

                //  Read showtimes from the database
                ReadShowtimesDB();

                //  Method to clear showtime input data
                ClearShowtimeInputs();

                //  Read movies from the database
                ReadMoviesDB();

                //  Read screening rooms from the database
                ReadScreeningRoomsDB();

                //  Methods to refresh selections for ComboBoxes
                ReadShowtimeMovieComboBox();
                ReadShowtimeRoomComboBox();

                //  Disable TextBoxes and Buttons to deny access for anymore changes made by the user
                showtimeDateTimePicker.Enabled = false;
                showtimeMovieComboBox.Enabled = false;
                showtimeRoomComboBox.Enabled = false;
                showtimeCostTextBox.Enabled = false;
                saveShowtimeButton.Enabled = false;
            }
        }

        private void deleteShowtimeButton_Click(object sender, EventArgs e)
        {
            //  Check if a ListBox selection for a showtime exists
            if (showtimesListBox.SelectedIndex < 0)
            {
                //  Show error message
                MessageBox.Show("Select a showtime from the ListBox.");
            }
            //  Otherwise continue actions
            else
            {
                //  Declare showtime
                Showtime deleteShowtime = new Showtime();

                //  Associate variables with inputted data by the user
                deleteShowtime.ID = int.Parse(showtimeIDTextBox.Text);
                deleteShowtime.Time = DateTime.Parse(showtimeDateTimePicker.Text);
                deleteShowtime.RoomCode = showtimeRoomComboBox.Text;
                deleteShowtime.TicketPrice = float.Parse(showtimeCostTextBox.Text);

                //  Clear list
                showtimeList.Clear();

                //  Call method to delete screening room from the list according to the screening room fields read
                dbManager.DeleteShowtimeDB(deleteShowtime);

                //  Clear ListBox
                showtimesListBox.Items.Clear();

                //  Read showtimes from the database
                ReadShowtimesDB();

                //  Method to clear showtime input data
                ClearShowtimeInputs();

                //  Methods to refresh selections for ComboBoxes
                ReadShowtimeMovieComboBox();
                ReadShowtimeRoomComboBox();
            }
        }

        private void ClearAddMovieInputs()
        {
            //  Clear TextBoxes
            addMovieTitleTextBox.Text = "";
            addMovieGenreComboBox.Text = "";
            addMovieYearTextBox.Text = "";
            addMovieLengthTextBox.Text = "";
            addMovieRatingTextBox.Text = "";
            addMovieImagePathTextBox.Text = "";

            //  Clear ComboBox
            addMovieGenreComboBox.Items.Clear();
        }

        private void RefreshAddMovieGenres()
        {
            //  Loop to repopulate addMovieGenreComboBox after a clear data method is used
            for (int i = 0; i < genreList.Count; i++)
            {
                addMovieGenreComboBox.Items.Add(genreList[i].Name);
            }
        }

        private void UpdateListView()
        {
            //  Clear ListView
            moviesListView.Items.Clear();

            //  For each item name add it to the ListView
            for (int i = 0; i < movieList.Count; i++)
            {
                //  Create ListViewItem to hold the title and year for each movie
                ListViewItem lvi = new ListViewItem();
                lvi.Text = movieList[i].Title;
                lvi.SubItems.Add(movieList[i].Year.ToString());

                //  Populate ListView with created LVI item
                moviesListView.Items.Add(lvi);
            }
        }

        private int InsertMovieDB(Movie addMovie)
        {
            try
            {
                //  The following objects will be used to create a movie item in the movie table
                MySqlConnection dbConnection8 = dbManager.CreateDBConnection();
                MySqlCommand dbCommand8;

                MySqlConnection dbConnection9 = dbManager.CreateDBConnection();
                MySqlCommand dbCommand9;

                //  Declare int variables for rows affected upon changes
                int queryResult1;
                int queryResult2;

                //  Open DB connection
                dbConnection8.Open();

                //  SQL query to execute in the db
                string sqlQuery1 = "INSERT INTO movie VALUES(@ID, @Title, @Year, @Length, @Rating, @ImagePath);";

                //  SQL containing the query to be executed
                dbCommand8 = new MySqlCommand(sqlQuery1, dbConnection8);

                //  Associate parameters with movie objects
                dbCommand8.Parameters.AddWithValue("@ID", addMovie.ID);
                dbCommand8.Parameters.AddWithValue("@Title", addMovie.Title);
                dbCommand8.Parameters.AddWithValue("@Year", addMovie.Year);
                dbCommand8.Parameters.AddWithValue("@Length", addMovie.Length);
                dbCommand8.Parameters.AddWithValue("@Rating", addMovie.Rating);
                dbCommand8.Parameters.AddWithValue("@ImagePath", addMovie.ImagePath);

                //  Prepare parameters to query in DB
                dbCommand8.Prepare();

                //  Result of rows affected
                queryResult1 = dbCommand8.ExecuteNonQuery();


                //  Open DB connection
                dbConnection9.Open();

                //  SQL query to execute in the db
                string sqlQuery2 = "INSERT INTO jt_genre_movie VALUES(@GenreCode, @ID);";

                //  SQL containing the query to be executed
                dbCommand9 = new MySqlCommand(sqlQuery2, dbConnection9);

                //  Associate parameters with movie and genre list objects
                dbCommand9.Parameters.AddWithValue("@GenreCode", genreList[addMovieGenreComboBox.SelectedIndex].Code);
                dbCommand9.Parameters.AddWithValue("@ID", addMovie.ID);

                //  Prepare parameters to query in DB
                dbCommand9.Prepare();

                //  Result of rows affected
                queryResult2 = dbCommand9.ExecuteNonQuery();

                //  Close DB connections
                dbConnection8.Close();
                dbConnection9.Close();

                return queryResult1;
            }
            catch
            {
                //  Error Message
                MessageBox.Show("Error upon movie insertion detected.");

                //  Open and close connection upon an error
                MySqlConnection dbConnection10 = dbManager.CreateDBConnection();

                //  Close DB connection
                dbConnection10.Close();

                return 0;
            }
        }

        private void addMovieButton_Click(object sender, EventArgs e)
        {
            //  Declare int and decimal variable for integer/decimal checking
            int num = -1;
            decimal d;

            //  Create array of TextBoxes
            var textBoxCollection = new[] { addMovieTitleTextBox, addMovieYearTextBox, addMovieLengthTextBox, addMovieImagePathTextBox, addMovieRatingTextBox };

            //  Declare boolean value to use for array
            bool atleastOneTextboxEmpty;

            //  Check if any TextBoxes are empty within the array
            if (atleastOneTextboxEmpty = textBoxCollection.Any(t => String.IsNullOrWhiteSpace(t.Text)))
            {
                //  Show error message
                MessageBox.Show("Not all entries for ADD MOVIE are filled.");
            }
            //  Check if ComboBox is empty
            else if (addMovieGenreComboBox.Text == "")
            {
                //  Show error message
                MessageBox.Show("Select a genre from the ComboBox.");
            }
            //  Integer checking for year
            else if (!int.TryParse(addMovieYearTextBox.Text, out num))
            {
                //  Show error message
                MessageBox.Show("Invalid year input. Use an integer instead.");
            }
            //  Integer checking for length
            else if (!int.TryParse(addMovieLengthTextBox.Text, out num))
            {
                //  Show error message
                MessageBox.Show("Invalid length input. Use an integer instead.");
            }
            //  Number checking for rating
            else if (!decimal.TryParse(addMovieRatingTextBox.Text, out d))
            {
                //  Show error message
                MessageBox.Show("Invalid rating input. Use a number instead.");
            }
            else
            {
                //  Replace inputted backslashes inserted by OpenFileDialog to forward slashes
                //  Due to MySQL deleting backslashes in its syntax when read
                //  Source: https://stackoverflow.com/questions/41935210/replace-all-blackslashes-with-forward-slash/41935242
                addMovieImagePathTextBox.Text = addMovieImagePathTextBox.Text.Replace("\\", "/");

                //  Declare random variable for ID
                Random rand = new Random();
                int idNum = rand.Next(200, 50000);

                //  Declare movie variable
                Movie addMovie = new Movie();

                //  New movie data values pointed to the add movie fields
                addMovie.ID = int.Parse(idNum.ToString());
                addMovie.Title = addMovieTitleTextBox.Text;
                addMovie.Year = int.Parse(addMovieYearTextBox.Text);
                addMovie.Length = int.Parse(addMovieLengthTextBox.Text);
                addMovie.Rating = double.Parse(addMovieRatingTextBox.Text);
                addMovie.ImagePath = addMovieImagePathTextBox.Text;

                //  Empty Movies list
                movieList = new List<Movie>();

                //  Call method to insert add movie fields from form to a movie object in the list
                InsertMovieDB(addMovie);

                //  Clear imageList for adding movie item
                movieImageList.Images.Clear();

                //  Read movies from the database
                ReadMoviesDB();

                //  Read movie list and display updated data
                UpdateListView();

                //  Method to clear add movie TextBox/ComboBox data
                ClearAddMovieInputs();

                //  Method to repopulate addMovieGenreComboBox after a clear data method is used
                RefreshAddMovieGenres();

                //  Update ComboBoxes with movie list changes
                ReadShowtimeMovieComboBox();
                ReadAddShowtimeMovieComboBox();
            }
        }

        private void addMovieImagePathButton_Click(object sender, EventArgs e)
        {
            //  Use FileDialog to search for an image to select
            OpenFileDialog addMovieImage = new OpenFileDialog();

            //  Set filter to only show images to select from
            addMovieImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";

            if (addMovieImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //  String variable for the file path and name taken from OpenFileDialog
                string selectedImagePath = addMovieImage.FileName;

                //  Set image path TextBox by the selected file
                addMovieImagePathTextBox.Text = selectedImagePath;
            }
        }

        private int DeleteMovieDB(Movie deleteMovie)
        {
            try
            {
                //  Open DB connection
                dbManager.dbConnection.Open();

                //  Declare int variables for rows affected upon changes
                int queryResult;
                int queryResult2;
                int queryResult3;

                //  ----If there are movie tickets purchased under a movie you are trying to delete----
                //  ----you must cancel the showtimes for that movie by deleting them first----


                //  ----Delete genre(s) associated with movie first to prevent foreign key error----

                //  SQL query to execute in the db
                string sqlQuery = "DELETE FROM jt_genre_movie WHERE movie_id = @ID;";

                //This is the actual SQL containing the query to be executed
                MySqlCommand dbCommand8 = new MySqlCommand(sqlQuery, dbManager.dbConnection);

                //  Associate parameter with movie object
                dbCommand8.Parameters.AddWithValue("@ID", deleteMovie.ID);

                //  Prepare parameters to query in DB
                dbCommand8.Prepare();

                queryResult = dbCommand8.ExecuteNonQuery();

                //  ----Delete showtime(s) associated with movie second to prevent foreign key error----

                string sqlQuery2 = "DELETE FROM showtime WHERE movie_id = @ID;";

                //  SQL containing the query to be executed
                MySqlCommand dbCommand9 = new MySqlCommand(sqlQuery2, dbManager.dbConnection);

                //  Associate parameter with movie object
                dbCommand9.Parameters.AddWithValue("@ID", deleteMovie.ID);

                //  Prepare parameters to query in DB
                dbCommand9.Prepare();

                queryResult2 = dbCommand9.ExecuteNonQuery();

                //  ----Delete movie according to ID----

                string sqlQuery3 = "DELETE FROM movie WHERE id = @ID;";

                //  SQL containing the query to be executed
                MySqlCommand dbCommand10 = new MySqlCommand(sqlQuery3, dbManager.dbConnection);

                //  Associate parameter with movie object
                dbCommand10.Parameters.AddWithValue("@ID", deleteMovie.ID);

                //  Prepare parameters to query in DB
                dbCommand10.Prepare();

                queryResult3 = dbCommand10.ExecuteNonQuery();

                //After executing the query(ies) in the db, the connection must be closed
                dbManager.dbConnection.Close();

                return queryResult;
            }
            catch
            {
                //  Error message
                MessageBox.Show("Error deleting movie. If there are movie tickets purchased under a movie you are " +
                    "trying to delete you must cancel the showtimes for that movie by deleting them first. Check showtimes in order to do this.");

                //  Open and close connection upon an error
                MySqlConnection dbConnection7 = dbManager.CreateDBConnection();

                dbConnection7.Close();

                return 0;
            }
        }

        private void deleteMovieButton_Click(object sender, EventArgs e)
        {
            //  If a ListView item is selected
            if (moviesListView.SelectedItems.Count > 0)
            {
                //  Declare movie variable
                Movie deleteMovie = new Movie();

                //  Selected movie data values pointed to the read only movie ID field
                deleteMovie.ID = int.Parse(idTextBox.Text);
                deleteMovie.Title = titleTextBox.Text;
                deleteMovie.Year = int.Parse(yearTextBox.Text);
                deleteMovie.Length = int.Parse(lengthTextBox.Text);
                deleteMovie.Rating = double.Parse(ratingTextBox.Text);
                deleteMovie.ImagePath = imagePathTextBox.Text;

                //  Empty Movies list
                movieList = new List<Movie>();

                //  Call method to delete movie from the list
                DeleteMovieDB(deleteMovie);

                //  Clear imageList for adding movie item
                movieImageList.Images.Clear();

                //  Read movies from the database
                ReadMoviesDB();

                //  Read movie list and display updated data
                UpdateListView();

                //  Remove movie data method
                ClearMovieInputs();

                //  Update ComboBoxes with movie list changes
                ReadShowtimeMovieComboBox();
                ReadAddShowtimeMovieComboBox();

                //  Clear list
                showtimeList.Clear();

                //  Clear ListBox
                showtimesListBox.Items.Clear();

                //  Read showtimes from the database
                ReadShowtimesDB();
            }
            else
            {
                //  Show prompt message
                MessageBox.Show("Select a movie first.");
            }
        }

        private void modifyMovieButton_Click(object sender, EventArgs e)
        {
            //  If a ListView item is selected
            if (moviesListView.SelectedItems.Count > 0)
            {
                //  Enable TextBoxes and Button to allow access for changes made by the user
                titleTextBox.Enabled = true;
                yearTextBox.Enabled = true;
                movieImagePathButton.Enabled = true;
                lengthTextBox.Enabled = true;
                ratingTextBox.Enabled = true;
                saveMovieButton.Enabled = true;
            }
            else
            {
                //  Show prompt message
                MessageBox.Show("Select a movie first.");
            }
        }

        private void movieImagePathButton_Click(object sender, EventArgs e)
        {
            //  Use FileDialog to search for an image to select
            OpenFileDialog modifyMovieImage = new OpenFileDialog();

            //  Set filter to only show images to select from
            modifyMovieImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";

            if (modifyMovieImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //  String variable for the file path and name taken from OpenFileDialog
                string selectedImagePath = modifyMovieImage.FileName;

                //  Set image path TextBox by the selected file
                imagePathTextBox.Text = selectedImagePath;
            }
        }

        private void saveMovieButton_Click(object sender, EventArgs e)
        {
            //  Declare int and decimal variable for integer/decimal checking
            int num = -1;
            decimal d;

            //  Create array of TextBoxes
            var textBoxCollection = new[] { titleTextBox, yearTextBox, lengthTextBox, imagePathTextBox, ratingTextBox };

            //  Declare boolean value to use for array
            bool atleastOneTextboxEmpty;

            //  Check if any TextBoxes are empty within the array
            if (atleastOneTextboxEmpty = textBoxCollection.Any(t => String.IsNullOrWhiteSpace(t.Text)))
            {
                //  Show error message
                MessageBox.Show("Not all entries for MODIFYING MOVIE are filled.");
            }
            //  Integer checking for year
            else if (!int.TryParse(yearTextBox.Text, out num))
            {
                //  Show error message
                MessageBox.Show("Invalid year input. Use an integer instead.");
            }
            //  Integer checking for length
            else if (!int.TryParse(lengthTextBox.Text, out num))
            {
                //  Show error message
                MessageBox.Show("Invalid length input. Use an integer instead.");
            }
            //  Number checking for rating
            else if (!decimal.TryParse(ratingTextBox.Text, out d))
            {
                //  Show error message
                MessageBox.Show("Invalid rating input. Use a number instead.");
            }
            else
            {
                //  Replace inputted backslashes inserted by OpenFileDialog to forward slashes
                //  Due to MySQL deleting backslashes in its syntax when read
                imagePathTextBox.Text = imagePathTextBox.Text.Replace("\\", "/");

                //  Declare movie variable
                Movie modifyMovie = new Movie();

                //  Modified movie data values pointed to the modify movie fields
                //  ID is not able to be changed due to it being the primary key
                modifyMovie.ID = int.Parse(idTextBox.Text);
                modifyMovie.Title = titleTextBox.Text;
                modifyMovie.Year = int.Parse(yearTextBox.Text);
                modifyMovie.Length = int.Parse(lengthTextBox.Text);
                modifyMovie.Rating = double.Parse(ratingTextBox.Text);
                modifyMovie.ImagePath = imagePathTextBox.Text;

                //  Empty Movies list
                movieList = new List<Movie>();

                //  Call method to insert add movie fields from form to a movie object in the list
                dbManager.ModifyMovieDB(modifyMovie);

                //  Clear imageList for adding movie item
                movieImageList.Images.Clear();

                //  Read movies from the database
                ReadMoviesDB();

                //  Read movie list and display updated data
                UpdateListView();

                //  Remove movie data method
                ClearMovieInputs();

                //  Update ComboBoxes with movie list changes
                ReadShowtimeMovieComboBox();
                ReadAddShowtimeMovieComboBox();

                //  Disable TextBoxes and Buttons to deny access for anymore changes made by the user
                titleTextBox.Enabled = false;
                yearTextBox.Enabled = false;
                movieImagePathButton.Enabled = false;
                lengthTextBox.Enabled = false;
                ratingTextBox.Enabled = false;
                saveMovieButton.Enabled = false;
            }
        }
    }
}
