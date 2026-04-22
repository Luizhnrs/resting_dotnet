using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Connection string for SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=mssql,1433;Initial Catalog=MyDatabase;User ID=sa;Password=Your_password123;TrustServerCertificate=True";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<resting_dotnet.Context.ClientDbContext>(options =>
    options.UseSqlServer(connectionString));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
