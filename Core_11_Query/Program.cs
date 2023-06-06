using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

CsAppContext context = new CsAppContext();

//var sorgu = await context.Persons.FromSqlInterpolated($"Select * from Persons")
//    .ToListAsync();

//var sorgu2=await context.Persons.FromSql($"SELECT * FROM Persons").Where(p=>p.Name.Contains("a")).ToListAsync();

//var sorgu = await context.Persons.FromSqlInterpolated($"EXEC sp_GetAllPersons null").ToListAsync();
//int productId = 3;
//var sorbu = await context.Persons.FromSql($"SELECT * FROM Persons Where PersonId={productId}").ToListAsync();
//var sorbu = await context.Persons.FromSql($"EXEC sp_GetAllPersons {productId}").ToListAsync();

//SqlParameter personId = new("PersonId","3");
//personId.DbType=System.Data.DbType.Int32;
//personId.Direction = System.Data.ParameterDirection.Input;
//var sorgu=await context.Persons.FromSql($"EXEC sp_GetAllPersons @PersonId={personId}").ToListAsync();

//string columnName = "PersonId";
//SqlParameter value = new("PersonId", "3");
//var sorgu = await context.Persons.FromSqlRaw($"Select * From Persons Where {columnName} = @PersonId", value).ToListAsync();

//var data= await context.Database.SqlQuery<int>($"SELECT PersonId Value FROM Persons")
//    .Where(x=>x<6).ToListAsync();

//await context.Database.ExecuteSqlAsync($"UPDATE Persons SET Name='Fatma' WHERE PersonId=1");

//var persons= await context.Persons.FromSql($"SELECT Name, PersonId FROM Persons").ToListAsync();

var datas = await context.PersonOrders
    .Where(p => p.Count > 10)
    .ToListAsync();

Console.WriteLine("as");
Console.WriteLine("as");

public class PersonOrder
{
    public string Name { get; set; }
    public int Count { get; set; }
}
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

    public Person Person { get; set; }
}

class CsAppContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<PersonOrder> PersonOrders { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Orders)
            .WithOne(o => o.Person)
            .HasForeignKey(o => o.PersonId);

        modelBuilder.Entity<PersonOrder>()
            .ToView("vm_PersonOrders")
            .HasNoKey();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Core_11_Query; Trusted_Connection=True");
    }
}
