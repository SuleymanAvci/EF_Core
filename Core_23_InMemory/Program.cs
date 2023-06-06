// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

CsAppContext context = new();

await context.Persons.AddAsync(new() { Name = "Ali", Surname = "Akan" });
await context.SaveChangesAsync();

var persons = await context.Persons.ToListAsync();
Console.WriteLine();

public class Person
{
    public int PersonId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}

public class CsAppContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("exampleDatabase");
    }
}

