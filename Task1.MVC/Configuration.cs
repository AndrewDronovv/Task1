using System.Data.Entity.Migrations;
using Task1.MVC.Data;

namespace Task1.MVC
{
    public class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}