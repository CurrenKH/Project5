using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    class ScreeningRoom
    {
        //  Properties for Screening Room
        public string Code { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }

        //  Constructor
        public ScreeningRoom()
        {
            Code = "";
            Capacity = 0;
            Description = "";
        }
    }
}
