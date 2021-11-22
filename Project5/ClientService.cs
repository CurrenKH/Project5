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
        }

        //  Declare class instance for SQL connection methods
        DBManager dbManager = new DBManager();

        private void PurchaseTicketButton_Click(object sender, EventArgs e)
        {
            //  Declare form
            TicketPurchase ticketPurchaseForm = new TicketPurchase();

            //  Show new form
            ticketPurchaseForm.ShowDialog(this);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            //  Closes the form
            this.Close();
        }

        private void MoviesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  If an item is selected
            /*if (moviesListView.SelectedItems.Count > 0)
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
            }*/
        }
    }
}
