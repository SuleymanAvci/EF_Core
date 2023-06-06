using Microsoft.EntityFrameworkCore;
using System.Reflection;

CsAppContext context = new();

//var emplayees = await context.Employees
//    .Include(e => e.Orders)
//    //.Where(e => e.Orders.Count() > 2)
//    .Include(e => e.Region)
//    .ToListAsync();

//var orders = await context.Orders
//    .Include(o => o.Employee)
//    .Include(o => o.Employee.Region)
//    .ToListAsync();

//var regions= await context.Regions
//    .Include(r=>r.Employees)
//    .ThenInclude(r=>r.Orders)
//    .ToListAsync();

//var regions =await context.Regions
//    .Include(r=>r.Employees
//    .Where(e=>e.Salary>=500)).ToListAsync();

//var orders=await context.Orders.ToListAsync();
//var employees=await context.Employees.IgnoreAutoIncludes().ToListAsync();


//var employees = await context.Employees.FirstOrDefaultAsync(x => x.Id == 2);

//await context.Entry(employees).Reference(a => a.Region).LoadAsync();

//await context.Entry(employees).Collection(a=>a.Orders).LoadAsync();

//var count=await context.Entry(employees).Collection(a=>a.Orders).Query().CountAsync();




Console.WriteLine("sa");
Console.WriteLine("sa");


public class Employee
{
    public int Id { get; set; }
    public int RegionId { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Salary { get; set; }

    public List<Order>? Orders { get; set; }
    public Region? Region { get; set; }
}

public class Region
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public ICollection<Employee>? Employees { get; set; }
}

public class Order
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public DateTime OrderDate { get; set; }

    public Employee? Employee { get; set; }
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
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Core_08_EagerExplisit; Trusted_Connection=True");
    }

}