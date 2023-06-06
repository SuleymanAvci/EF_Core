
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;


CsAppContext context = new CsAppContext();

var persons = new List<Person>()
{
    new(){ Name = "Ayşe", Surname="Lae", BirtDate=DateTime.UtcNow},
    new(){ Name = "Hilmi",Surname="Lae",BirtDate=DateTime.UtcNow },
    new(){ Name = "Raziye" ,Surname="Lae",BirtDate=DateTime.UtcNow},
    new(){ Name = "Süleyman" ,Surname="Lae",BirtDate=DateTime.UtcNow},
    new(){ Name = "Fadime" ,Surname="Lae",BirtDate=DateTime.UtcNow},
    new(){ Name = "Şuayip",Surname="Lae",BirtDate=DateTime.UtcNow },
    new(){ Name = "Lale" ,Surname="Lae",BirtDate=DateTime.UtcNow},
    new(){ Name = "Jale" ,Surname="Lae",BirtDate=DateTime.UtcNow},
    new(){ Name = "Rıfkı",Surname="Lae",BirtDate=DateTime.UtcNow },
    new(){ Name = "Muaviye" ,Surname="Lae",BirtDate=DateTime.UtcNow}
    };




Console.WriteLine("as");
public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime BirtDate { get; set; }
}

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
}






class CsAppContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //modelBuilder.Entity<Employee>().ToTable("Employees", builder=>builder.IsTemporal());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Core_19_Resiliency; Trusted_Connection=True");
    }
}