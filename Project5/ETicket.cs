using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    class ETicket
    {
        //  Properties for ETicket
        public int ID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int ShowtimeID { get; set; }
        public int UserID { get; set; }

        //  Constructor
        public ETicket()
        {
            ID = 0;
            PurchaseDate = new DateTime();
            ShowtimeID = 0;
            UserID = 0;
        }
    }
}
