using Microsoft.EntityFrameworkCore;

namespace Mission6.Models;

public class FilmEnterContext : DbContext
{
    // context file is liason between the program and the database
    // constructor to set up options: 
    public FilmEnterContext(DbContextOptions<FilmEnterContext> options) : base(options)
    {
        
    }
    // create a table in the database
    public DbSet<Film> Movies { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    
    
}

// necessary imports:
// Microsoft.EntityFrameworkCore
// .Design, .sqlite