using Microsoft.EntityFrameworkCore;
namespace ConsoleApp1;
public class DataBase:DbContext
{
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Stock> Stocks => Set<Stock>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Cars.db");
    }
    
}