namespace proyectoef;
using Microsoft.EntityFrameworkCore;
using Models;

public class ActivityContext : DbContext
{
    public DbSet<Category> Categories {get;set;}
    public DbSet<Activity> Activities {get;set;}
    public ActivityContext(DbContextOptions<ActivityContext> options) : base(options){  }
}