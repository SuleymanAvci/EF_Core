// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;

Console.WriteLine("Hello, World!");

CsAppContext context = new();

Employee e1 = new() { Name = "Tuana", Surname = "Avcı", Department = "Uçak" };
//Employee e2 = new() { Name = "Ayla", Surname = "Avcı", Department = "Uçak" };
//Customer c1 = new() { Name = "Mehmet", Surname = "Avcı", CompanyName = "Dandan" };
//Customer c2 = new() { Name = "Hakan", Surname = "Avcı", CompanyName = "Kardan" };
//Technician t1 = new() { Name = "Mustafa", Surname = "Avcı", Department = "kale", Branch = "Yazilim" };
//await context.Employees.AddAsync(e1);
//await context.Employees.AddAsync(e2);
//await context.Customers.AddAsync(c1);
//await context.Customers.AddAsync(c2);
//await context.Technicians.AddAsync(t1);
//await context.SaveChangesAsync();

//Employee e1 = await context.Employees.FindAsync(3);
//context.Employees.Remove(e1);
//await context.SaveChangesAsync();

//var customers = await context.Customers.ToListAsync();
//context.RemoveRange(customers);
//await context.SaveChangesAsync();

//Employee employee =await context.Employees.FindAsync(4);
//employee.Name="Test";
//await context.SaveChangesAsync();

var employees = await context.Employees.ToListAsync();
var technician = await context.Technicians.ToListAsync();

Console.WriteLine("as");

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
}
public class Employee : Person
{
    public string? Department { get; set; }
}
public class Customer : Person
{
    public string? CompanyName { get; set; }
}

public class Technician : Employee
{
    public string? Branch { get; set; }
}



public class CsAppContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasDiscriminator<string>("Ayirici");
        //.HasValue<Person>(1)
        //.HasValue<Employee>(2)
        //.HasValue<Customer>(3)
        //.HasValue<Technician>(4);

    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Technician> Technicians { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Core_06_TablePerHierarchy; Trusted_Connection=True");
    }

}