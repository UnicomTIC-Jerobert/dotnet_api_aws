using Microsoft.EntityFrameworkCore;
using SimpleTodoApi.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Add the database context and configure it to use SQLite.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=todos.db";
builder.Services.AddSqlite<TodoContext>(connectionString);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 2. A simple way to create the database if it doesn't exist.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TodoContext>();
    context.Database.EnsureCreated();
}

app.Run();