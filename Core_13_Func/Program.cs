
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;

CsAppContext context = new CsAppContext();


//var persons=await (from person in context.Persons
//                    where context.GetPersonTotalOrderPrice(person.PersonId) > 30
//                    select person).ToListAsync();

var persons = await context.BestSellingStaff(200).ToListAsync();
foreach (var person in persons)
{
    Console.WriteLine($"Name : {person.Name} | Order Count : {person.OrderCount} | Total Order Price : {person.TotalOrderPrice}");

}



Console.WriteLine("as");


public class Person
{
    public int PersonId { get; set; }
    public string Name { get; set; }

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

[NotMapped]
public class BestSellingStaff
{
    public string Name { get; set; }
    public int OrderCount { get; set; }
    public int TotalOrderPrice { get; set; }
}

class CsAppContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.HasDbFunction(typeof(CsAppContext).GetMethod(nameof(CsAppContext.GetPersonTotalOrderPrice), new[] { typeof(int) })).HasName("getPersonTotalOrderPrice");

        modelBuilder.HasDbFunction(typeof(CsAppContext).GetMethod(nameof(CsAppContext.BestSellingStaff), new[] { typeof(int) })).HasName("bestSellingStaff");

        modelBuilder.Entity<BestSellingStaff>()
            .HasNoKey();

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Orders)
            .WithOne(o => o.Person)
            .HasForeignKey(o => o.PersonId);
    }

    public int GetPersonTotalOrderPrice(int personId)
        => throw new Exception();

    public IQueryable<BestSellingStaff> BestSellingStaff(int totalOrderPrice = 10000)
        => FromExpression(() => BestSellingStaff(totalOrderPrice));

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=CsAppDB_13_Func; Trusted_Connection=True");
    }
}
