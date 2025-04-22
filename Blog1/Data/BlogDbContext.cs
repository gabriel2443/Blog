using Blog1.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog1.Data;

public class BlogDbContext : DbContext
{

    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    
public DbSet<Blog> Blogs { get; set; }

}