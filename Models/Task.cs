using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ef_todo;

[Table("Task")] // If we need to spicify the table name for DB model
public class Task
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("CategoryId")] // Relation with Category model | Data Annotation
    public Guid CategoryId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }

    [Column("Created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("Modified_at")]
    public DateTime ModifiedAt { get; set; }

    [Column("Deleted_at")]
    public DateTime DeletedAt { get; set; }
    public virtual Category Category { get; set; } //With virtual, I can Get information about Category Model.

    [NotMapped] // Not created on DB
    public string Summary { get; set; } // Refers to the shortest of decription And it will be virtual not on DB
}

public enum Priority
{
    Low,
    Medium,
    Hight
}
