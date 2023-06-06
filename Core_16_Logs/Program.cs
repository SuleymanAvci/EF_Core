
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Reflection;


CsAppContext context = new CsAppContext();


//var datas = await context.Persons.ToListAsync();

//await context.Persons
//    .Include(x => x.Orders)
//    .Where(x => x.Name.Contains("a"))
//    .Select(x => new {x.Name, x.PersonId})
//    .ToListAsync();



//var datas1 = await context.Persons.TagWith("Örnek bir açıklama...").Include(p=>p.Orders).TagWithCallSite("Orderler sorguya eklendi...").ToListAsync();

var datas = await context.Persons.ToListAsync();

var datas1 = await context.Persons.IgnoreQueryFilters().ToListAsync();


Console.WriteLine("as");
Console.WriteLine("as");


public class Person
{
    public int PersonId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

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

        modelBuilder.Entity<Person>().HasQueryFilter(p => p.IsActive);

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Orders)
            .WithOne(o => o.Person)
            .HasForeignKey(o => o.PersonId);
    }



    readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder
    .AddFilter((category, level) =>
    {
        return category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information;
    })
    .AddConsole());

    //StreamWriter _log = new("logs.txt", append: true);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Core_16_Logs; Trusted_Connection=True");
        optionsBuilder.UseLoggerFactory(loggerFactory);
        //optionsBuilder.LogTo(message => Debug.WriteLine(message));
        //optionsBuilder.LogTo(async message => await _log.WriteLineAsync(message), LogLevel.Information)
        //    .EnableSensitiveDataLogging()
        //    .EnableDetailedErrors();
    }

    //public override void Dispose()
    //{        
    //    _log.Dispose();
    //    base.Dispose();
    //}

    //public override async ValueTask DisposeAsync()
    //{
    //    await _log.DisposeAsync();
    //    await base.DisposeAsync();
    //}
}
