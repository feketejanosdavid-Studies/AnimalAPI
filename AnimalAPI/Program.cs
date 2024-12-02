using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AnimalAPI.Data;
var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<AnimalAPIContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("AnimalAPIContext") ?? throw new InvalidOperationException("Connection string 'AnimalAPIContext' not found.")));

var conString = builder.Configuration.GetConnectionString("AnimalAPIContextMySQL");
builder.Services.AddDbContext<AnimalAPIContext>(options =>
    options.UseMySql(conString,ServerVersion.AutoDetect(conString)));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
