namespace proyectoef;
using Microsoft.EntityFrameworkCore;
using Models;

public class ActivityContext : DbContext
{
    public DbSet<Category> Categories {get;set;}
    public DbSet<Activity> Activities {get;set;}
    public ActivityContext(DbContextOptions<ActivityContext> options) : base(options){  }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(category => {
            category.ToTable("Category");
            category.HasKey(p => p.CategoryID);
            category.Property( p => p.CategoryName).IsRequired().HasMaxLength(150);
            category.Property(p => p.CategoryDescription).HasMaxLength(200);
        });


        modelBuilder.Entity<Activity>(activity => {
            activity.ToTable("Activity");
            activity.HasOne(p => p.Category).WithMany(p => p.Activity).HasForeignKey(p => p.CategoryID);
            //activity.HasAlternateKey(p=> p.CategoryID); 
            activity.Property(p => p.Title).IsRequired().HasMaxLength(200);
            activity.Property(p => p.Description);
            activity.Property(p => p.createdDate);
            activity.Property(p => p.priorityActivity);
            //activity.Property(p => p.Category);
            activity.Property(p => p.Resume);

        });
    }

}