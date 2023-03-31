using ef_todo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("EFTodoDB")); // Config using EF core to use Memory DB
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

app.Run();
