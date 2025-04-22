using Blog1.Models;

namespace Blog1.Service;

public interface IBlogService
{
    public  Task<List<Blog>> GetAllBlogs();
    public Task<Blog?> GetBlogById(int id);

    public Task CreateBlog(Blog blog);

}