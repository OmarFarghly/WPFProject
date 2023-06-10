using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Model;

namespace WpfProject.DataBaseContext
{
    public class MyDbContext :DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        

        public MyDbContext() : base("name=ITISys")
        {
            // Ensure that the database is created if it doesn't exist
            Database.SetInitializer(new CreateDatabaseIfNotExists<MyDbContext>());
        }
    }
   
      
}
