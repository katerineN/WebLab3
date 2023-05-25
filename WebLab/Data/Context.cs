using Microsoft.EntityFrameworkCore;
using WebLab.Models;

namespace WebLab.Data;

public class Context:DbContext
{
   public Context (DbContextOptions<Context> options)
        : base(options)
    {
    }

    public DbSet<ContactForm> FormContacts { get; set; }
       
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=MyDatabase.db");
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactForm>().ToTable("FormContacts");
    }
}