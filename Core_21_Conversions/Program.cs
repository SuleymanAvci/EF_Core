// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;

Console.WriteLine("Hello, World!");

var context = new CsAppContext();

//var persons = await context.Persons.ToListAsync();
//foreach (var person in persons)
//    Console.WriteLine(person.Gender);

//var person = new Person() { Name = "Canan", Gender = Gender.Famele};
//await context.Persons.AddAsync(person);
//await context.SaveChangesAsync();
//var person2 = await context.Persons.FindAsync(person.Id);
//Console.WriteLine(person2.Name + " " + person2.Gender);

//var person = new Person()
//{
//    Name = "Merve",
//    Gender = Gender.Famele,
//    Married = true,
//    Titles = new() { "A", "B", "C" }
//};

//await context.Persons.AddAsync(person);
//await context.SaveChangesAsync();

var person2 = await context.Persons.FindAsync(11);

Console.WriteLine(person2.Name + " " + person2.Titles);


public class GenderConverter : ValueConverter<Gender, string>
{
    public GenderConverter() : base(
        //Insert - Update
        g => g.ToString()
        ,
        //Select
        g => (Gender)Enum.Parse(typeof(Gender), g)
        )
    {

    }
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }
    public bool Married { get; set; }
    public List<String>? Titles { get; set; }
}

public enum Gender
{
    Male,
    Famele
}

public class CsAppContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        #region ValueConverter
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Gender)
        //    .HasConversion(
        //    //Insert - Update
        //    g => g.ToUpper()
        //    ,
        //    //Select
        //    g => g == "M" ? "Male" : "Female"
        //    );
        #endregion
        #region EnumConverter
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Gender)
        //    .HasConversion(
        //    //Insert - Update
        //    g=>g.ToString()
        //    //g => (int)g
        //    ,
        //    //Select
        //    g => (Gender)Enum.Parse(typeof(Gender), g)
        //    );
        #endregion
        #region ValueConverter Sınıfı
        //ValueConverter<Gender, string> converter=new(
        //    //Insert - Update
        //    g => g.ToString()
        //    //g => (int)g
        //    ,
        //    //Select
        //    g => (Gender)Enum.Parse(typeof(Gender), g)
        //    );
        //modelBuilder.Entity<Person>()
        //  .Property(p => p.Gender)
        //  .HasConversion(converter);
        #endregion
        #region CustomConverter
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Gender)
        //    .HasConversion<GenderConverter>();
        #endregion
        #region BoolToZeroOneConverter
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Married)
        //    .HasConversion<BoolToZeroOneConverter<int>>();
        //    //.HasConversion<int>();
        #endregion
        #region BoolToStringConverter
        //BoolToStringConverter converter = new("Bekar", "Evli");
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Married)
        //    .HasConversion(converter);
        #endregion
        #region BoolToStringConverter
        //BoolToTwoValuesConverter<char> converter = new('B', 'E');
        //modelBuilder.Entity<Person>()
        //    .Property(p => p.Married)
        //    .HasConversion(converter);
        #endregion
        #region Ilkel Koleksiyonların Serilizasyonu
        modelBuilder.Entity<Person>()
            .Property(p => p.Titles)
            .HasConversion(
            //Insert - Update
            t => JsonSerializer.Serialize(t, (JsonSerializerOptions)null)
            ,
            //Select
            t => JsonSerializer.Deserialize<List<string>>(t, (JsonSerializerOptions)null)
            );
        #endregion


    }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=Localhost,7433; Initial Catalog=Core_21_Conversions; User ID=Sa; Password=myPa55-word; TrustServerCertificate=true");
    }

}