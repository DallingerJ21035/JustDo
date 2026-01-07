using Microsoft.EntityFrameworkCore;

namespace JustDoDb;

public class JustDoDbContext: DbContext
{
    public JustDoDbContext(DbContextOptions<JustDoDbContext> options) : base(options) { }
    public JustDoDbContext() { }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Console.WriteLine($"Db OnConfiguring: IsConfigured={optionsBuilder.IsConfigured}");
        if (optionsBuilder.IsConfigured) return;
        string connectionstring = @"server=(LocalDB)\mssqllocaldb;attachdbfilename=D:\Temp\Persons.mdf;database=Persons;integrated security=True;MultipleActiveResultSets=True;";
        Console.WriteLine($"Using connectionString {connectionstring}");
        optionsBuilder.UseSqlServer(connectionstring);
    }
}
