using Microsoft.EntityFrameworkCore;
using ef_todo.Models;
namespace ef_todo;

public class TodoContext : DbContext
{
    //Categories and Tasks represents all collections about themself
    public DbSet<Category> Categories { get; set; }
    public DbSet<TaskModel> Tasks { get; set; }

    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options) { }

    // Re create = OVERRIDE always should be protected method no public
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Category> categoriesInit = new List<Category>();
        categoriesInit.Add(
            new Category()
            {
                Id = Guid.Parse("fdbda192-37af-49e1-a125-21a5fa03e3e8"),
                Name = "Pendant Activities",
                Weight = 20
            }
        );
        categoriesInit.Add(
            new Category()
            {
                Id = Guid.Parse("fdbda192-37af-49e1-a125-21a5fa03e302"),
                Name = "Personal Activities",
                Weight = 50
            }
        );

        modelBuilder.Entity<Category>(category =>
        {
            category.ToTable("Category"); //Category should be singular because database says that tables will be in singular
            category.HasKey(p => p.Id);
            category.Property(p => p.Name).IsRequired().HasMaxLength(150);
            category.Property(p => p.Description).IsRequired(false);
            category.HasData(categoriesInit); // Seed data
        });

        List<TaskModel> tasksInit = new List<TaskModel>();
        tasksInit.Add(
            new TaskModel()
            {
                Id = Guid.Parse("fdbda192-37af-49e1-a125-21a5fa03e3f4"),
                CategoryId = Guid.Parse("fdbda192-37af-49e1-a125-21a5fa03e3e8"),
                Title = "Pay Taxes in Lost country",
                Description =
                    "I need to go to the post office to get ticket and pay the ammount ehehe",
                Priority = Priority.Medium,
                Done = Status.False,
                CreatedAt = DateTime.UtcNow
            }
        );
        tasksInit.Add(
            new TaskModel()
            {
                Id = Guid.Parse("fdbda192-37af-49e1-a125-21a5fa03e3f5"),
                CategoryId = Guid.Parse("fdbda192-37af-49e1-a125-21a5fa03e302"),
                Title = "Go to the Gym",
                Description = "I need to 10 kilometers",
                Priority = Priority.Hight,
                Done = Status.False,
                CreatedAt = DateTime.UtcNow
            }
        );

        modelBuilder.Entity<TaskModel>(task =>
        {
            task.ToTable("Task");
            task.HasKey(p => p.Id);
            task.HasOne(p => p.Category).WithMany(p => p.Tasks).HasForeignKey(p => p.CategoryId);
            task.Property(p => p.Title).IsRequired().HasMaxLength(200);
            task.Property(p => p.Description).IsRequired(false);
            task.Property(p => p.Priority);
            // .HasConversion(v => v.ToString(), v => (priority)Enum.Parse(typeof(priority), v));
            task.Property(p => p.CreatedAt).HasColumnName("Created_at");
            task.Property(p => p.ModifiedAt)
                .HasColumnName("Modified_at")
                .HasDefaultValue(DateTime.Parse("01-01-1900").ToUniversalTime());
            task.Property(p => p.DeletedAt)
                .HasColumnName("Deleted_at")
                .HasDefaultValue(DateTime.Parse("01-01-1900").ToUniversalTime());
            task.Property(p => p.Done)
                .HasConversion(v => v.ToString(), v => (Status)Enum.Parse(typeof(Status), v));
            task.Ignore(p => p.Summary);
            task.HasData(tasksInit);
        });
    }
}
