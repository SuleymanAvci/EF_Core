
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Storage;

CsAppContext context = new CsAppContext();

//IDbContextTransaction transaction = context.Database.BeginTransaction();

//context.Database.CommitTransaction();
//context.Database.RollbackTransaction();

//bool connect=context.Database.CanConnect();
//Console.WriteLine(connect);

//context.Database.EnsureCreated();
//context.Database.EnsureDeleted();

//var script = context.Database.GenerateCreateScript();
//Console.WriteLine(script);
//string name = Console.ReadLine();
//var result = context.Database.ExecuteSql($"Insert Person Values('{name}')");
//var result2 = context.Database.ExecuteSqlRaw($"Insert Person Values(' {name} ')')");

//var result = context.Database.GetMigrations();
//var result2 = context.Database.GetAppliedMigrations();
//var result3 = context.Database.GetPendingMigrations();
//context.Database.Migrate();
//Console.WriteLine(result);

//context.Database.OpenConnection();
//context.Database.CloseConnection();

//Console.WriteLine(context.Database.GetConnectionString());

//SqlConnection connection=(SqlConnection)context.Database.GetDbConnection();
//SqlConnection connection2=(SqlConnection)context.Database.SetDbConnection();

//Console.WriteLine(context.Database.ProviderName);


Console.WriteLine("as");
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

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Orders)
            .WithOne(o => o.Person)
            .HasForeignKey(o => o.PersonId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Core_14_Database; Trusted_Connection=True");
    }
}
