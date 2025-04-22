using Blog1.Data;
using Blog1.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Blog1.Service;

public class BlogService : IBlogService
{
    private readonly BlogDbContext _blogContext;

    public BlogService(BlogDbContext blogContext)
    {
        _blogContext = blogContext;
        
    }


    public async Task<List<Blog>> GetAllBlogs()
    {

        return await _blogContext.Blogs.ToListAsync();

    }

    public async Task<Blog?> GetBlogById(int id)
    {
        
        return await _blogContext.Blogs.FindAsync(id);
    }


    public async Task CreateBlog(Blog blog)
    {

       
     _blogContext.Blogs.Add(blog);
     await _blogContext.SaveChangesAsync();
     
    }

    public async Task UpdateBlog(int id,Blog blog)
    {

        var currBlog = await GetBlogById(id);
        
        currBlog.Title = blog.Title;
        currBlog.Category = blog.Category;
        currBlog.Tags = blog.Tags;
        currBlog.UpdatedAt = DateTime.UtcNow;
       

    await _blogContext.SaveChangesAsync();


    }

    public async Task<bool>DeleteBlog(int id)
    {
        var curBlog = await GetBlogById(id);
        if(curBlog is not null) _blogContext.Blogs.Remove(curBlog);
        await _blogContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Blog>> SearchElements(string term)
    {
        var blogs= await GetAllBlogs();
        
        var filteredBlogs = blogs.Where(b => b.Title.ToLower().Contains(term) || b.Category.ToLower().Contains(term) || b.Tags.ToString().ToLower().Contains(term));
        return filteredBlogs.ToList();
    }
    
}
