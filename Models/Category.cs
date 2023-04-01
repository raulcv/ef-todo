using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ef_todo.Models;

// [Table("StudentMaster", Schema="Admin")]
//[Table("Category")]
public class Category
{
    //[Key] //DataAnnotations
    public Guid Id { get; set; }

    //[Required] //DataAnnotations
    //[MaxLength(150)] //DataAnnotations
    public string Name { get; set; }
    public string Description { get; set; }
    public int Weight { get; set; }
    [JsonIgnore]
    public virtual ICollection<TaskModel> Tasks { get; set; } //With virtual ICollection<Task>, I can Get list of tasks with specific category ID. | relation with Task
}
