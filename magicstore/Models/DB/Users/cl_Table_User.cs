using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace magicstore.Models
{
    public class cl_Table_User
    {
        public Int32 Id { get; set; }
        public Guid UID { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Login { get; set; }
        public String Password { get; set; }
        public DateTime Registration { get; set; }
        public DateTime LastIn { get; set; }
        public Boolean Blocked { get; set; }
        public String EMail { get; set; }
        public Boolean EMailConfirm { get; set; }
        public String Address { get; set; }
        public String Permission { get; set; }

    }
}