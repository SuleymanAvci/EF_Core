using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

Console.WriteLine("as");
CsAppContext context = new();

//var blog=await context.Blogs.FindAsync(3);
//var createDate  = context.Entry(blog).Property("CreatedDate");

//Console.WriteLine(createDate.CurrentValue);
//Console.WriteLine(createDate.OriginalValue);

//createDate.CurrentValue = DateTime.Now;
//context.SaveChanges();

var blogs = await context.Blogs.OrderBy(p => EF.Property<DateTime>(p, "CreatedDate")).ToListAsync();

var blogs2 = await context.Blogs.Where(p => EF.Property<DateTime>(p, "CreatedDate").Year > 2022).ToListAsync();

Console.WriteLine();
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
    public string? Title { get; set; }
    public DateTime lostUpdated { get; set; }
    public Blog? Blog { get; set; }
}

class CsAppContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB; Database=CsAppDB_02; Trusted_Connection=True");
    }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }


    #region OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>()
            .Property<DateTime>("CreatedDate");

        base.OnModelCreating(modelBuilder);
    }
    #endregion
}