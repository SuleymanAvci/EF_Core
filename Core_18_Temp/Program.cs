
using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

CsAppContext context = new CsAppContext();

//var persons = new List<Person>()
//{
//    new(){ Name = "Ayşe", Surname="Lae", BirtDate=DateTime.UtcNow},
//    new(){ Name = "Hilmi",Surname="Lae",BirtDate=DateTime.UtcNow },
//    new(){ Name = "Raziye" ,Surname="Lae",BirtDate=DateTime.UtcNow},
//    new(){ Name = "Süleyman" ,Surname="Lae",BirtDate=DateTime.UtcNow},
//    new(){ Name = "Fadime" ,Surname="Lae",BirtDate=DateTime.UtcNow},
//    new(){ Name = "Şuayip",Surname="Lae",BirtDate=DateTime.UtcNow },
//    new(){ Name = "Lale" ,Surname="Lae",BirtDate=DateTime.UtcNow},
//    new(){ Name = "Jale" ,Surname="Lae",BirtDate=DateTime.UtcNow},
//    new(){ Name = "Rıfkı",Surname="Lae",BirtDate=DateTime.UtcNow },
//    new(){ Name = "Muaviye" ,Surname="Lae",BirtDate=DateTime.UtcNow}
//};

//await context.Persons.AddRangeAsync(persons);
//await context.SaveChangesAsync();

//var person = await context.Persons.FindAsync(4);
//person.Name = "Dana";
//await context.SaveChangesAsync();

//var person = await context.Persons.FindAsync(3);
//context.Persons.Remove(person);
//await context.SaveChangesAsync();

//var datas = await context.Persons.TemporalAsOf(new DateTime(2023, 05, 03, 19, 00, 00)).Select(x => new
//{
//    x.Id,
//    x.Name,
//    PeriodStart = EF.Property<DateTime>(x, "PeriodStart"),
//    PeriodEnd = EF.Property<DateTime>(x, "PeriodEnd"),
//}).ToListAsync();

//var datas = await context.Persons.TemporalAll().Select(x => new
//{
//    x.Id,
//    x.Name,
//    PeriodStart = EF.Property<DateTime>(x, "PeriodStart"),
//    PeriodEnd = EF.Property<DateTime>(x, "PeriodEnd"),
//}).ToListAsync();

//var baslangic=new DateTime(2023,05,03,0,0,0,0);
//var bitis=new DateTime(2023,05,03,23,59,59);

//var datas = await context.Persons.TemporalFromTo(baslangic,bitis).Select(x => new
//{
//    x.Id,
//    x.Name,
//    PeriodStart = EF.Property<DateTime>(x, "PeriodStart"),
//    PeriodEnd = EF.Property<DateTime>(x, "PeriodEnd"),
//}).ToListAsync();

//foreach (var data in datas)
//{
//    Console.WriteLine(data);
//}

var dataOfDelete = await context.Persons.TemporalAll()
    .Where(x => x.Id == 3)
    .OrderByDescending(x => EF.Property<DateTime>(x, "PeriodEnd"))
    .Select(x => EF.Property<DateTime>(x, "PeriodEnd"))
    .FirstAsync();

var deletedPerson = await context.Persons.TemporalAsOf(dataOfDelete.AddMicroseconds(-1))
    .FirstOrDefaultAsync(p => p.Id == 3);

await context.AddAsync(deletedPerson);
await context.Database.OpenConnectionAsync();

await context.Database.ExecuteSqlInterpolatedAsync($"Set IDENTITY_INSERT dbo.Persons ON");
await context.SaveChangesAsync();
await context.Database.ExecuteSqlInterpolatedAsync($"Set IDENTITY_INSERT dbo.Persons OFF");



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
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Employee>().ToTable("Employees", builder => builder.IsTemporal());
        modelBuilder.Entity<Person>().ToTable("Persons", builder => builder.IsTemporal());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Core_18_Temp; Trusted_Connection=True");
    }
}
