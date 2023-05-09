using proyectoef;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ActivityContext>(p => p.UseInMemoryDatabase("ActivityDB"));

builder.Services.AddSqlServer<ActivityContext>("Data Source=DESKTOP-EK3C038; Initial Catalog=ActivityDB;user id=AlejandraHuerta;password:12345");
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] ActivityContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database in memory" + dbContext.Database.IsInMemory());
});
app.Run();
