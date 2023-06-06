using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System.Reflection;

CsAppContext context = new();

var employees = await context.Employees.FindAsync(2);
Console.WriteLine(employees.Region.Name);

Console.WriteLine("sa");
Console.WriteLine("sa");

public class Employee
{
    ILazyLoader _lazyLoader;
    Region _region;
    public Employee() { }
    public Employee(ILazyLoader lazyLoader)
        => _lazyLoader = lazyLoader;


    public int Id { get; set; }
    public int RegionId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Salary { get; set; }

    public List<Order>? Orders { get; set; }
    public Region? Region
    {
        get => _lazyLoader.Load(this, ref _region);
        set => _region = value;
    }
}

public class Region
{
    LazyLoader _lazyLoader;
    ICollection<Employee> _employee;
    public Region() { }
    public Region(LazyLoader lazyLoader)
       => _lazyLoader = lazyLoader;
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Employee>? Employees
    {
        get => _lazyLoader.Load(this, ref _employee);
        set => _employee = value;
    }
}

public class Order
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }

    public virtual Employee? Employee { get; set; }
}


public class CsAppContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //modelBuilder.Entity<Employee>().Navigation(x => x.Region).AutoInclude();
    }

    public DbSet<Employee>? Employees { get; set; }
    public DbSet<Region>? Regions { get; set; }
    public DbSet<Order>? Orders { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies(false)
            .UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Core_09_Lazy; Trusted_Connection=True");
    }

}