namespace ef_todo;

public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    //With virtua ICollection<Task>, I can Get list of tasks with specific category ID.
    public virtual ICollection<Task> Tasks { get; set; }
}
