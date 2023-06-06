
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;


CsAppContext context = new();

//IDbContextTransaction transaction= await context.Database.BeginTransactionAsync();

//Person p = new() { Name="Mustafa"};
//await context.Persons.AddAsync(p);
//await context.SaveChangesAsync();

//await transaction.CommitAsync();

IDbContextTransaction transaction = await context.Database.BeginTransactionAsync();

var p13 = await context.Persons.FindAsync(13);
var p11 = await context.Persons.FindAsync(13);
context.Persons.RemoveRange(p13, p11);

await transaction.CreateSavepointAsync("t1");
var p10 = await context.Persons.FindAsync(10);
context.Persons.Remove(p10);
await context.SaveChangesAsync();

await transaction.RollbackToSavepointAsync("t1");

await transaction.CommitAsync();

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


class CsAppContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //modelBuilder.Entity<Person>()
        //    .HasMany(p => p.Orders)
        //    .WithOne(o => o.Person)
        //    .HasForeignKey(o => o.PersonId);
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=Localhost,7433; Initial Catalog=Core_22_Transactions; User ID=Sa; Password=myPa55-word; TrustServerCertificate=true");
    }
}