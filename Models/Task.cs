namespace ef_todo;

public class Task
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Tittle { get; set; }
    public string Description { get; set; }
    public Priority Priority { get; set; }
    public DateTime CreatedDateTime { get; set; }

    //With virtua, I can Get information about Category Model.
    public virtual Category Category { get; set; }
}

public enum Priority
{
    Low,
    Medium,
    Hight
}
