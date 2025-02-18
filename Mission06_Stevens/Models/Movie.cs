using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Mission06_Stevens.Models;

public class Movie
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    public int CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))] 
    public Category? Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public int Year { get; set; }
    public string? Director { get; set; }
    public string? Rating { get; set; }
    [Required]
    public bool Edited { get; set; }
    public string? LentTo { get; set; }
    [Required]
    public bool CopiedToPlex { get; set;}
    public string? Notes { get; set; }
    
    
}