namespace proyectoef.Models;
using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public Guid CategoryID{get; set;}
    [Required]
    [MaxLength(150)]
    public string CategoryName{get;set;}
    public string CategoryDescription{get;set;}
    public virtual ICollection<Activity> Activity {get;set;}

}