using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    class UserAccount
    {
        //  Properties for UserAccount
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public int TypeID { get; set; }
        public DateTime SignupDate { get; set; }

        //  Constructor
        public UserAccount()
        {
            ID = 0;
            Name = "";
            Username = "";
            Password = "";
            EmailAddress = "";
            TypeID = 0;
            SignupDate = new DateTime();
        }
    }
}
