using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    class Showtime
    {
        //  Properties for Showtime
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public int MovieID { get; set; }
        public string RoomCode { get; set; }
        public float TicketPrice { get; set; }

        //  Constructor
        public Showtime()
        {
            ID = 0;
            Time = new DateTime();
            MovieID = 0;
            RoomCode = "";
            TicketPrice = 0;
        }
    }
}
