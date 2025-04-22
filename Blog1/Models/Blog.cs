using System.ComponentModel.DataAnnotations;

namespace Blog1.Models;

public class Blog
{
    [Key]
    public int BlogId { get; set; }
    [StringLength(100)]
    public string? Title { get; set; }
    [StringLength(100)]
    public string? Category { get; set; }
    public string[]? Tags { get; set; }
    public DateTime CreatedAt { get; init; } =DateTime.Now;
    public DateTime UpdatedAt { get; set; }=DateTime.Now;
    
    
    
}