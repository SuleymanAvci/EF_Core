
using Microsoft.EntityFrameworkCore;
using System.Reflection;

CsAppContext context = new();

//var query = from photo in context.Photos
//            join person in context.Persons
//                 on photo.PersonId equals person.PersonId
//            select new
//            {
//                person.Name,
//                photo.Url
//            };

//var query = context.Photos
//    .Join(context.Persons,
//    photo=>photo.PersonId,
//    person=>person.PersonId,
//    (photo, person)=>new
//    {
//        person.Name,
//        photo.Url
//    });

//var query = from photo in context.Photos
//            join person in context.Persons
//              on new { photo.PersonId, photo.Url } equals new { person.PersonId, Url= person.Name }
//            select new
//            {
//                photo.Url,
//                person.Name
//            };

//var query = context.Photos
//    .Join(context.Persons,
//    photo => new
//    {
//        photo.PersonId,
//        photo.Url
//    },
//    person => new
//    {
//        person.PersonId,
//        Url=person.Name
//    },
//    (photo, person) => new
//    {
//        person.Name,
//        photo.Url
//    });


//var query = from person in context.Persons
//            join photo in context.Photos
//            on person.PersonId equals photo.PersonId
//            join order in context.Orders
//            on person.PersonId equals order.PersonId
//            select new
//            {
//                person.PersonId,
//                photo.Url,
//                order.Description
//            };

//var query = context.Persons
//    .Join(context.Photos,
//    person => person.PersonId,
//    photo => photo.PersonId,
//    (person, photo) => new
//    {
//        person.PersonId,
//        person.Name,
//        photo.Url
//    })
//    .Join(context.Orders,
//    ilkTablo=>ilkTablo.PersonId,
//    order=>order.PersonId,
//    (ilkTablo, order) => new
//    {
//        ilkTablo.PersonId,
//        ilkTablo.Name,
//        ilkTablo.Url,
//        order.Description
//    });


var query = from person in context.Persons
            join order in context.Orders
              on person.PersonId equals order.PersonId into personOrders
            //from order in personOrders
            select new
            {
                person.Name,
                Count = personOrders.Count(),
                personOrders
            };


var datas = await query.ToListAsync();

Console.WriteLine("as");

public class Photo
{
    public int PersonId { get; set; }
    public string Url { get; set; }
    public Person Person { get; set; }
}

public enum Gender { Man, Woman }
public class Person
{
    public int PersonId { get; set; }
    public string Name { get; set; }
    public Gender Gender { get; set; }

    public Photo Photo { get; set; }
    public ICollection<Order> Orders { get; set; }
}
public class Order
{
    public int OrderId { get; set; }
    public int PersonId { get; set; }
    public string Description { get; set; }

    public Person Person { get; set; }
}
public class CsAppContext : DbContext
{
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Photo>()
    .HasKey(p => p.PersonId);

        modelBuilder.Entity<Person>()
            .HasOne(p => p.Photo)
            .WithOne(p => p.Person)
            .HasForeignKey<Photo>(p => p.PersonId);

        modelBuilder.Entity<Person>()
            .HasMany(p => p.Orders)
            .WithOne(o => o.Person)
            .HasForeignKey(o => o.PersonId);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Core_10_Join; Trusted_Connection=True");
    }

}