
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;

Console.WriteLine("sa");

CsAppContext context = new();

//var persons = await context.Persons.Where(p=>p.Name.Contains("as"))
//                                .Take(3)
//                                .ToListAsync();

//*****************************

//var persons2 =  context.Persons.Where(p => p.Name.Contains("as"))
//                                .AsEnumerable()
//                                .Take(3)
//                                .ToList();

//*****************************


//var persons =await context.Persons.Include(p => p.Orders
//                                                .Where(o => o.Price > 5 && o.Price % 2 == 0)
//                                                .OrderByDescending(o => o.OrderId)
//                                                .Take(5))
//    .ToListAsync();

//***************************** Explicit

//var persons = await context.Persons.FirstOrDefaultAsync(p => p.PersonId == 3);

//if (persons.Name =="Hasan")
//{
//    await context.Entry(persons).Collection(p=>p.Orders).LoadAsync();
//}



Console.WriteLine("as");

public class Person
{
    public int PersonId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<Order> Orders { get; set; }
}

public class Order
{
    public int OrderId { get; set; }
    public int PersonId { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }

    public Person Person { get; set; }
}


public class CsAppContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=Localhost,7433; Initial Catalog=Core_24_Efficient_Querying; User ID=Sa; Password=myPa55-word; TrustServerCertificate=true");
    }
}
