using Microsoft.EntityFrameworkCore;
using TP2Console.Models.EntityFramework;
using TP3Rest.Models.DataManager;
using TP3Rest.Models.EntityFramework;
using TP3Rest.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SeriesDBContext>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("DBContext")));

builder.Services.AddScoped<IDataRepository<Utilisateur>, UtilisateurManager>();

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
