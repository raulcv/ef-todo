using ef_todo;
using ef_todo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("EFTodoDB")); // Config using EF core to use Memory DB

// builder.Services.AddSqlServer<TodoContext>("Data Source=PC-RAULCV-12343YU40\\SQLEXPRESS:Initial Catalog=EFTodoDB;user id=sa;password=mypassword");
builder.Services.AddNpgsql<TodoContext>(
    builder.Configuration.GetConnectionString("EFTodoDBConnectionString")
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet(
    "/dbconnection",
    async ([FromServices] TodoContext dbcontext) =>
    {
        dbcontext.Database.EnsureCreated();
        return Results.Ok("Data base in Mmemory: " + dbcontext.Database.IsInMemory());
    }
);

app.MapGet(
    "/api/tasks",
    async ([FromServices] TodoContext dbContext) =>
    {
        return Results.Ok(
            dbContext.Tasks.Include(p => p.Category).Where(p => p.Priority == Priority.Hight)
        // .Where(p => p.DeletedAt != DateTime.Parse("1-1-1900").ToUniversalTime())
        );
    }
);

app.MapGet(
    "/api/tasks/priority/{id}",
    async ([FromServices] TodoContext dbContext, int id) =>
    {
        var data = dbContext.Tasks
            .Include(a => a.Category)
            .Where(
                a =>
                    (int)a.Priority == id
                    && a.DeletedAt != DateTime.Parse("1-1-1900").ToUniversalTime()
            );
        return Results.Ok(data);
    }
);

app.MapPost(
    "/api/tasks",
    async ([FromServices] TodoContext dbContext, [FromBody] TaskModel task) =>
    {
        task.Id = Guid.NewGuid();
        task.CreatedAt = DateTime.UtcNow;
        await dbContext.AddAsync(task);
        // await dbContext.Tasks.AddAsync(task); Another way to add data to DB Using EF
        await dbContext.SaveChangesAsync();
        return Results.Ok("Task was deleted");
    }
);

app.MapPut(
    "/api/tasks/{id}",
    async ([FromServices] TodoContext dbContext, [FromBody] TaskModel task, [FromRoute] Guid id) =>
    {
        var currentTask = dbContext.Tasks.Find(id);
        if (currentTask != null)
        {
            currentTask.CategoryId = task.CategoryId;
            currentTask.Title = task.Title;
            currentTask.Description = task.Description;
            currentTask.Priority = task.Priority;
            currentTask.Done = task.Done;
            currentTask.ModifiedAt = DateTime.UtcNow;
            await dbContext.SaveChangesAsync();
            return Results.Ok("Modified");
        }
        return Results.NotFound("Task not found");
    }
);
app.MapPatch(
    "/api/tasks/toggle/{id}",
    async ([FromServices] TodoContext dbContext, [FromRoute] Guid id) =>
    {
        var currentTask = dbContext.Tasks.Find(id);
        if (currentTask != null)
        {
            Console.WriteLine(currentTask.DeletedAt);
            Console.WriteLine(DateTime.Parse("1-1-1900").ToUniversalTime());
            if (currentTask.DeletedAt == DateTime.Parse("1-1-1900").ToUniversalTime())
            {
                currentTask.DeletedAt = DateTime.UtcNow;
                await dbContext.SaveChangesAsync();
                return Results.Ok("Tas was disabled");
            }
            else
            {
                currentTask.DeletedAt = DateTime.Parse("1-1-1900").ToUniversalTime();
                await dbContext.SaveChangesAsync();
                return Results.Ok("Tas was Enabled");
            }
        }
        return Results.NotFound("Task not found");
    }
);

app.MapDelete(
    "/api/tasks/{id}",
    async ([FromServices] TodoContext dbContext, [FromRoute] Guid id) =>
    {
        var currentTask = dbContext.Tasks.Find(id);
        if (currentTask != null)
        {
            dbContext.Remove(currentTask);
            await dbContext.SaveChangesAsync();
            return Results.Ok("Tas was deleted");
        }
        return Results.NotFound("Task not found");
    }
);

app.Run();
