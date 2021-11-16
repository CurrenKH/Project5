using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    class Genre
    {
        //  Properties for Genre
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //  Constructor
        public Genre()
        {
            Code = "";
            Name = "";
            Description = "";
        }
    }
}
