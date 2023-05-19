namespace proyectoef.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Activity
{
    //[Key]
    public Guid ActivityID{get; set;}
    //[ForeignKey("CategoryID")]
    public Guid CategoryID{get; set;}
    //[Required]
    //[MaxLength(200)]
    public string Title {get; set;}
    public string Description{get; set;}
    public Priority priorityActivity{get; set;}
    [NotMapped]
    public DateOnly createdDate{get; set;}
    public virtual Category Category {get; set;}
    [NotMapped]
    public string Resume {get; set;}
    
}

public enum Priority
{
    Low,
    Medium,
    High
}