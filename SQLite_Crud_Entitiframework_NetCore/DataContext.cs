
using Microsoft.EntityFrameworkCore;

namespace SQLite_Crud_Entitiframework_NetCore
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = UserData.db");
        }

        public DbSet<User> Users { get; set; }
    }
}
