using Microsoft.EntityFrameworkCore;

namespace ef_todo;

public class TodoContext : DbContext
{
    //Categories and Tasks represents all collections about themself
    public DbSet<Category> Categories { get; set; }
    public DbSet<Task> Tasks { get; set; }

    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options) { }
}
