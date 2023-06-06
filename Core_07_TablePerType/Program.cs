// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;

Console.WriteLine("Hello, World!");

CsAppContext context = new();

//Technician t1 = new() {Name="aaaa",Surname="Aaaavcı",Department="Yazılım",Branch="Teknik"};
//await context.Technicians.AddAsync(t1);
//await context.SaveChangesAsync();

//Customer c2 = new() { Name = "Can", Surname = "Can", CompanyName="Mere"};
//await context.Customers.AddAsync(c2);
//await context.SaveChangesAsync();

//var e1=await context.Employees.FindAsync(4);
//context.Employees.Remove(e1);
//await context.SaveChangesAsync();

//Technician technician = await context.Technicians.FindAsync(2);
//technician.Name= "Tuana";
//await context.SaveChangesAsync();

var datas = await context.Technicians.ToListAsync();

Console.WriteLine("as");

public abstract class Person
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
        modelBuilder.Entity<Person>().ToTable("Persons");
        modelBuilder.Entity<Employee>().ToTable("Employees");
        modelBuilder.Entity<Customer>().ToTable("Customers");
        modelBuilder.Entity<Technician>().ToTable("Technicians");
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Technician> Technicians { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Core_07_TablePerType; Trusted_Connection=True");
    }

}