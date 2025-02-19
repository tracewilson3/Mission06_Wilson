using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Mission6.Models;

namespace Mission6.Models;

public class Film
{
    
    [Key]
    public int MovieId { get; set; }
    
    [ForeignKey("CategoryId")]
    [Required(ErrorMessage = "Category is required.")]
    
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Category is required.")]
    public Category Category { get; set; }
    
    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Year is required.")]
    public int Year { get; set; }
    [Range(1888,2050)]

    
    public string? Director { get; set; } // not required

    [Required(ErrorMessage = "Rating is required.")]
    public string? Rating { get; set; }

    public int Edited { get; set; }
    
    public string? LentTo { get; set; } // Not required
    
    [StringLength(25, ErrorMessage = "Notes cannot exceed 25 characters.")]
    
    public string CopiedToPlex { get; set; }
    public string? Notes { get; set; } // Not required
}