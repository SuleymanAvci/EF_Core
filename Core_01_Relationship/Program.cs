
using Microsoft.EntityFrameworkCore;

Console.WriteLine("as");
CsAppContext context = new();

#region Added
#region OneToOne Relationship Data Added

//Person person = new();
//person.Name = "Ali";
//person.Address = new Address() { PersonAddress = "Sincan/ Merkez mah." };

//await context.AddAsync(person);
//await context.SaveChangesAsync();
////-----
//Address address = new();
//address.PersonAddress = "Bala/ Konaklar";
//address.Person = new Person() { Name = "Süleyman" };

//await context.AddAsync(address);
//await context.SaveChangesAsync();

#endregion
#region  OneToMany Relationship Data Added

//Blog blog = new() { Name = "Slmaavc@gmail.com" };
//blog.Posts.Add(new() { Title = "Post 1" });
//blog.Posts.Add(new() { Title = "Post 2" });
//blog.Posts.Add(new() { Title = "Post 3" });
//await context.AddAsync(blog);
//await context.SaveChangesAsync();

////----
//Blog blog2 = new()
//{
//    Name = "A Blog",
//    Posts = new HashSet<Post>()
//    {
//      new() { Title = "Dene 1" },
//      new() { Title = "Dene 2" }
//    }
//};
//await context.AddAsync(blog2);
//await context.SaveChangesAsync();

////----
//Post post3 = new()
//{
//    BlogId = 1,
//    Title = "Dene"
//};
//await context.AddAsync(post3);
//await context.SaveChangesAsync();

#endregion
#region ManyToMany Relationship Data Added
#region 1.Yontem (default convention)
//Book book = new()
//{
//    BookName = "Karanlıklar",
//    Authors = new HashSet<Author>()
//    {
//        new(){AuthorName="Suleyman"},
//        new(){AuthorName="Mustafa"},
//        new(){AuthorName="Tuana"}
//    }
//};
//await context.Books.AddAsync(book);
//await context.SaveChangesAsync();

//Author author = new()
//{
//    AuthorName = "Tarkan",
//    Books = new HashSet<Book>()
//    {
//        new() { BookName = "Dandanakan"}
//    }
//};
//await context.AddAsync(author);
//await context.SaveChangesAsync();
#endregion
#region 2.Yontem (fluent api)
//Author author = new()
//{
//    AuthorName = "Veli",
//    Books = new HashSet<AuthorBook>()
//    {
//        new() {BooksId = 1},
//        new() { Book =new() { BookName="Dann"} }
//    }
//};
//await context.AddAsync(author);
//await context.SaveChangesAsync();


//Book book1 = new() { BookName = "1.Kitap" };
//Book book2 = new() { BookName = "2.Kitap" };
//Book book3 = new() { BookName = "3.Kitap" };

//Author author1 = new() { AuthorName = "1.Yazar" };
//Author author2 = new() { AuthorName = "2.Yazar" };
//Author author3 = new() { AuthorName = "3.Yazar" };

//book1.Authors.Add(author1);
//book1.Authors.Add(author2);

//book2.Authors.Add(author1);
//book2.Authors.Add(author2);
//book2.Authors.Add(author3);

//book3.Authors.Add(author3);

//await context.AddAsync(book1);
//await context.AddAsync(book2);
//await context.AddAsync(book3);
//await context.SaveChangesAsync();

#endregion
#endregion
#endregion

#region Update
#region OneToOne Relationship Data Update

//Person? person = await context.Persons.Include(p => p.Address).FirstOrDefaultAsync(x => x.Id == 1);
//context.Addresses.Remove(person.Address);

//person.Address = new()
//{
//    PersonAddress = "Yeni Adres"
//};
//await context.SaveChangesAsync();

////------
//Address? address = await context.Addresses.FindAsync(2);
//context.Addresses.Remove(address);
//await context.SaveChangesAsync();

//Person person2 = new() { Name = "Hasan" };
//address.Person = person2;

//await context.Addresses.AddAsync(address);
//await context.SaveChangesAsync();

#endregion
#region OneToMany Relationship Data Update

//Blog? blog = await context.Blogs.Include(c => c.Posts).FirstOrDefaultAsync(b => b.Id == 1);
//Post? silinecek = blog.Posts.FirstOrDefault(p => p.Id == 2);
//blog.Posts.Remove(silinecek);

//blog.Posts.Add(new() { Title = "4 title" });
//blog.Posts.Add(new() { Title = "5 title" });
//await context.SaveChangesAsync();
////-----
//Post post = await context.Posts.FindAsync(4);
//Blog blog2 = new()
//{ Name = "lale@gmail.com" };
//post.Blog = blog2;
//await context.SaveChangesAsync();
////-----
//Post? post2 = await context.Posts.FindAsync(6);
//Blog? blog3 = await context.Blogs.FindAsync(2);
//post2.Blog = blog3;
//await context.SaveChangesAsync();

#endregion
#region ManyToMany Relationship Data Update

//Author author = await context.Authors.FindAsync(13);
//Book book = await context.Books.FindAsync(9);
//book.Authors.Add(author);
//await context.SaveChangesAsync();

////----
//Author? author = await context.Authors.Include(a=>a.Books).FirstOrDefaultAsync(a => a.Id == 13);
//foreach (var book in author.Books)
//{
//    if (book.Id != 11)
//        author.Books.Remove(book);
//}
//await context.SaveChangesAsync();

////----
//Book? book = await context.Books.Include(b => b.Authors).FirstOrDefaultAsync(a => a.Id == 4);
//Author silinecekYazar = book.Authors.FirstOrDefault(a => a.Id == 6);
//book.Authors.Remove(silinecekYazar);

//Author author = await context.Authors.FindAsync(3);
//book.Authors.Add(author);
//book.Authors.Add(new() { AuthorName = "4. Yazar" });
//await context.SaveChangesAsync();
#endregion
#endregion

#region Delete
#region OneToOne Relationship Data Delete
//Person? person = await context.Persons.Include(p => p.Address).FirstOrDefaultAsync(p => p.Id == 1);
//if (person != null)
//    context.Addresses.Remove(person.Address);
//await context.SaveChangesAsync();
#endregion
#region OneToMany Relationship Data Delete
//Blog? blog = await context.Blogs.Include(b => b.Posts).FirstOrDefaultAsync(b => b.Id == 1);
//Post? post = blog.Posts.FirstOrDefault(p => p.Id == 8);

//context.Posts.Remove(post);
//await context.SaveChangesAsync();
#endregion
#region ManyToMany Relationship Data Delete

//Author? author = await context.Authors.Include(a=>a.Books).FirstOrDefaultAsync(a=>a.Id==3);
//Book? book= author.Books.FirstOrDefault(b=>b.Id==4);
//author.Books.Remove(book);
//await context.SaveChangesAsync();
#endregion
#region Cascade-Isnull-Restrict Delete
//Person person=await context.Persons.FindAsync(2);
//context.Persons.Remove(person);
//await context.SaveChangesAsync();
#endregion

#endregion

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public Address? Address { get; set; }
}
public class Address
{
    public int Id { get; set; }
    //public int PersonId { get; set; }
    public string? PersonAddress { get; set; }
    public Person? Person { get; set; }
}
public class Blog
{
    public Blog()
    {
        Posts = new HashSet<Post>();
    }
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Post>? Posts { get; set; }
}
public class Post
{
    public int Id { get; set; }
    public int? BlogId { get; set; }
    public string? Title { get; set; }
    public Blog? Blog { get; set; }
}

#region ManyToMany Entity (default convention)
public class Book
{
    public Book()
    {
        Authors = new HashSet<Author>();
    }
    public int Id { get; set; }
    public string BookName { get; set; }
    public ICollection<Author> Authors { get; set; }
}
public class Author
{
    public Author()
    {
        Books = new HashSet<Book>();
    }
    public int Id { get; set; }
    public string AuthorName { get; set; }
    public ICollection<Book> Books { get; set; }
}
#endregion

#region ManyToMany Entity (fluent api)
//public class Book
//{
//    public Book()
//    {
//        Authors = new HashSet<AuthorBook>();
//    }
//    public int Id { get; set; }
//    public string BookName { get; set; }
//    public ICollection<AuthorBook> Authors { get; set; }
//}
//public class AuthorBook
//{
//    public int BooksId { get; set; }
//    public int AuthorsId { get; set; }
//    public Book Book { get; set; }
//    public Author Author { get; set; }
//}
//public class Author
//{
//    public Author()
//    {
//        Books = new HashSet<AuthorBook>();
//    }
//    public int Id { get; set; }
//    public string AuthorName { get; set; }
//    public ICollection<AuthorBook> Books { get; set; }
//}
#endregion

class CsAppContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=Core_01_Relationship; Trusted_Connection=True");
    }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    #region OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasOne(a => a.Address)
            .WithOne(a => a.Person)
            .HasForeignKey<Address>(a => a.Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Address>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<Post>()
            .HasOne(p => p.Blog)
            .WithMany(a => a.Posts)
            .OnDelete(DeleteBehavior.SetNull) //.Restrict
            .IsRequired(false);

        //modelBuilder.Entity<AuthorBook>()
        //    .HasOne(a => a.Book)
        //    .WithMany(a => a.Authors)
        //    .HasForeignKey(a => a.BooksId);

        //modelBuilder.Entity<AuthorBook>()
        //    .HasOne(a => a.Author)
        //    .WithMany(a => a.Books)
        //    .HasForeignKey(a => a.AuthorsId);

        //modelBuilder.Entity<AuthorBook>()
        //    .HasKey(a => new { a.BooksId, a.AuthorsId });
    }
    #endregion
}