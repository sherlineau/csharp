#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;

public class MyContext : DbContext
{
  public MyContext(DbContextOptions options) : base(options) {}
  
  // table name is determined by DbSet<singular row> plural table {getset}
  public DbSet<Dish> Dishes { get; set; }
}
