using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Reflection.Emit;
Console.WriteLine("As");

CsAppContext context = new CsAppContext();

//var persons = new List<Person>()
//{
//    new(){ Name = "Ayşe", },
//    new(){ Name = "Hilmi",},
//    new(){ Name = "Raziye"},
//    new(){ Name = "SüleymaNow"},
//    new(){ Name = "Fadime"},
//    new(){ Name = "Şuayip"},
//    new(){ Name = "Lale"},
//    new(){ Name = "Jale"},
//    new(){ Name = "Rıfkı"},
//    new(){ Name = "Muaviyeow"}
//};
//await context.Persons.AddRangeAsync(persons);
//await context.SaveChangesAsync();

#region Pessimistic Lock(Kötümser Kilitleme)
//var transaction = await context.Database.BeginTransactionAsync();
//var Data = await context.Persons.FromSqlRaw($"Select * From Persons With (XLOCK) Where Id=5").ToListAsync();

//Console.WriteLine("as");
//await transaction.CommitAsync();
#endregion

#region Optimistic Lock(İyimser Kilitleme)

//var person = await context.Persons.FindAsync(3);
//context.Entry(person).State = EntityState.Modified;
//await context.SaveChangesAsync();
#endregion


#region RowVersion Column

var person = await context.Persons.FindAsync(3);
context.Entry(person).State = EntityState.Modified;
await context.SaveChangesAsync();

#endregion
public class Person
{
    public int Id { get; set; }
    //[ConcurrencyCheck]
    public string? Name { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }

}


class CsAppContext : DbContext
{
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        //modelBuilder.Entity<Person>().Property(p=>p.Name).IsConcurrencyToken();
        modelBuilder.Entity<Person>().Property(p => p.RowVersion).IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=localhost; Database=CsAppDB_19; Trusted_Connection=True");
        optionsBuilder.UseSqlServer("Data Source=Localhost,7433;Initial Catalog=Core_20_Concurrency; User ID=Sa; Password=myPa55-word; TrustServerCertificate=true");
    }
}