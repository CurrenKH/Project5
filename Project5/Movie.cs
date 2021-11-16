using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    class Movie
    {
        //  Properties for Movie
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Length { get; set; }
        public string Director { get; set; }
        public double Rating { get; set; }
        public string ImagePath { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Showtime> Showtime { get; set; }

        //  Constructor
        public Movie()
        {
            ID = 0;
            Title = "";
            Year = 0;
            Length = 0;
            Director = "";
            Rating = 0;
            ImagePath = "";
            Genres = new List<Genre>();
            Showtime = new List<Showtime>();
        }
    }
}
