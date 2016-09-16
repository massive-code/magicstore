using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace magicstore.Models
{
    public class cl_DB_Users : DbContext
    {
        public DbSet<cl_Table_User> Users { get; set; }
    }
}