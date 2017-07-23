using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestUralsibins.Models
{
    public class FileContext : DbContext

    {
        public FileContext()
            :base("DbConnection")
        { }

        public DbSet<File> Files{ get; set; }
}
}