using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

CsAppContext context = new();
#region add
//Person person = new();
//person.Department = new()
//{
//    DepartmentName = "Yazilim"

//};
//person.Name = "Ali";
//person.Surname = "Kaya";

//await context.AddAsync(person);
//await context.SaveChangesAsync();
#endregion

//var person = await context.Persons.FindAsync(1);
//person.Name = "Tuana";
//await context.SaveChangesAsync();


Console.WriteLine("as");


//[Table("Kisiler")]
public class Person
{
    //[Key]
    public int Id { get; set; }
    //[ForeignKey(nameof(Department))]
    public int DId { get; set; }
    public int DepartmentId { get; set; }
    //[Column("Adi",TypeName ="metin")]
    //[Unicode]
    public string? Name { get; set; }
    //[Required] [MaxLength(100)]
    public string Surname { get; set; }
    //[Precision(4,3)]
    public decimal Salery { get; set; }
    //[NotMapped]
    //public string Kale { get; set; }
    //[Timestamp]

    //public byte[] RowVersion { get; set; }
    public DateTime CreatedDate { get; set; }
    public Department? Department { get; set; }
}
public class Department
{
    public int Id { get; set; }
    public string? DepartmentName { get; set; }
    public ICollection<Person> Persons { get; set; }
}

public class CsAppContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=CsAppDB_03; Trusted_Connection=True");
    }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region GetEntityTypes
        //var entities =modelBuilder.Model.GetEntityTypes();
        //foreach (var entityType in entities)
        //{
        //    Console.WriteLine(entityType.Name); 
        //}
        #endregion
        #region ToTable
        //modelBuilder.Entity<Person>().ToTable("Personeller");
        #endregion
        #region Column
        //modelBuilder.Entity<Person>()
        //    .Property(e => e.Name)
        //    .HasColumnName("Adi")
        //    .HasColumnType("dd")
        //    .HasColumnOrder(3);
        #endregion
        #region ForeignKey
        //modelBuilder.Entity<Person>()
        //    .HasOne(p => p.Department)
        //    .WithMany(d => d.Persons)
        //    .HasForeignKey(p => p.DId);
        #endregion
        #region Ignore
        //modelBuilder.Entity<Person>()
        //    .Ignore(p => p.Kale);
        #endregion
        #region PrimaryKey
        //modelBuilder.Entity<Person>().HasKey(p => p.No);
        #endregion
        #region IsRowVersion
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.RowVersion)
        //    .IsRowVersion();
        #endregion
        #region Requiredd
        //modelBuilder.Entity<Person>()
        //    .Property(x => x.Surname).IsRequired();
        #endregion
        #region MaxLength
        //modelBuilder.Entity<Person>()
        //.Property(x => x.Surname)
        //.HasMaxLength(100);
        #endregion
        #region Precision
        //modelBuilder.Entity<Person>()
        //.Property(x => x.Salery)
        //.HasPrecision(5, 3);
        #endregion
        #region Unicode
        //modelBuilder.Entity<Person>()
        //.Property(x => x.Name)
        //.IsUnicode();
        #endregion
        #region Comment
        //modelBuilder.Entity<Person>()
        //    .HasComment("Bu tablo için yorum")
        //    .Property(x => x.Name)
        //    .HasComment("Bu Konon için yorum");
        #endregion
        #region CompositeKey
        modelBuilder.Entity<Person>().HasKey(p => new { p.Id, p.DId });
        #endregion
    }
}