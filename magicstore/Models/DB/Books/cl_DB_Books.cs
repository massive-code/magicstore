using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace magicstore.Models
{
    public class cl_DB_Books : DbContext
    {
        public DbSet<cl_Table_Book> Users { get; set; }
    }
}