using Blog1.Models;

namespace Blog1.Service;

public interface IBlogService
{
    public  Task<List<Blog>> GetAllBlogs();
    public Task<Blog?> GetBlogById(int id);

    public Task CreateBlog(Blog blog);

    public Task UpdateBlog(int id, Blog blog);

    public Task<bool> DeleteBlog(int id);
    public Task<List<Blog>> SearchElements(string term);

}