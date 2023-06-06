using Microsoft.EntityFrameworkCore;

// Seed Data

Console.WriteLine("sa");

CsAppContext context = new();
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
    public string? Content { get; set; }
    public Blog? Blog { get; set; }
}

public class CsAppContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .HasData(
                new Blog() { Id = 1, Name = "www.karalen.com" },
                new Blog() { Id = 2, Name = "www.dsfddd.com" }
            );
        modelBuilder.Entity<Post>()
            .HasData(
            new Post() { Id = 1, BlogId = 1, Title = "A", Content = "..." },
            new Post() { Id = 2, BlogId = 1, Title = "B", Content = "..." }
            );
    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=Core_05; Trusted_Connection=True");
    }

}
