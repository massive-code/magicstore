using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace magicstore.Models
{
    public class cl_User
    {
        public Guid UID { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Login { get; set; }
        public String EMail { get; set; }
        public String Address { get; set; }
        public String Permission { get; set; }

    }
}