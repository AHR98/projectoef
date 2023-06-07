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
        List<Category> categoryList = new List<Category>();
        categoryList.Add(new Category() { CategoryID = Guid.Parse("fb96f653-96dd-4345-8159-9df23c22673d"), CategoryName = "Pending activities"});
        modelBuilder.Entity<Category>(category => {
            category.ToTable("Category");
            category.HasKey(p => p.CategoryID);
            category.Property( p => p.CategoryName).IsRequired().HasMaxLength(150);
            category.Property(p => p.CategoryDescription).HasMaxLength(200);

            category.HasData(categoryList);
        });

        List<Activity> activityInit = new List<Activity>();
        activityInit.Add(new Activity() {ActivityID = Guid.Parse("fb96f653-96dd-4345-8159-9df23c226710"), CategoryID = Guid.Parse("fb96f653-96dd-4345-8159-9df23c22673d"), priorityActivity = Priority.Medium, Title = "PAYMENT", createdDate = DateTime.Now});

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

            activity.HasData(activityInit);

        });
    }

}