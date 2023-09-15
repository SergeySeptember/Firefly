using Microsoft.EntityFrameworkCore;
using Product_Management_Service.Models.Product;

namespace Product_Management_Service.Services.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Books> Books { get; set; }
    }
}
