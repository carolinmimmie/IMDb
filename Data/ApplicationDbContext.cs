using IMDb.Domain;
using Microsoft.EntityFrameworkCore;

namespace IMDb.Data;

public class ApplicationDbContext : DbContext
{

  private string connectionString = "Server=.;Database=IMDb;Integrated Security=false;Encrypt=False;User ID=SA;Password=Dinoaugust123456!;";

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseSqlServer(connectionString);
  }
  //Kunna prata med tabellen som skapades
  public DbSet<Movie> Movie { get; set; }
  public DbSet<Actor> Actor{ get; set; }
}
