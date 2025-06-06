using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using Task1.MVC.Models;

namespace Task1.MVC.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext() : base(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString)
        {
        }
        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}