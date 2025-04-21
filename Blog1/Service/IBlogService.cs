namespace Blog1.Models.Service;

public interface IBlogService
{
    public  Task<List<Blog>> GetAllBlogs();
    public Task<Blog?> GetBlogById(int id);

    public Task CreateBlog(Blog blog);

}