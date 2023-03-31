using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef_todo;

// [Table("StudentMaster", Schema="Admin")]
[Table("Category")]
public class Category
{
    [Key] //DataAnnotations
    public Guid Id { get; set; }

    [Required] //DataAnnotations
    [MaxLength(150)] //DataAnnotations
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Task> Tasks { get; set; } //With virtua ICollection<Task>, I can Get list of tasks with specific category ID.
}
