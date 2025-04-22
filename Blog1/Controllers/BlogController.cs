using Blog1.Data;
using Blog1.Models;
using Blog1.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog1.Controllers
{
    [Route("api/v1/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
         
        public BlogController(IBlogService blogService)
        {
            
            _blogService= blogService;
            
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            
            return Ok(await _blogService.GetAllBlogs());
            
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            return Ok(await _blogService.GetBlogById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(Blog blog)
        {
            await _blogService.CreateBlog(blog);
            
            return CreatedAtAction(nameof(GetBlogById), new { id = blog.BlogId }, blog);
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, Blog blog)
        {
            await _blogService.UpdateBlog(id, blog);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            
           await  _blogService.DeleteBlog(id);
           return NoContent();
            
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchElements(string term)
        {
            return Ok(await _blogService.SearchElements(term));
        }
        
    }
}
