using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SleepTrackerApi.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SleepTrackerApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SleepTrackerApiContext") ?? throw new InvalidOperationException("Connection string 'SleepTrackerApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowCORS", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowCORS");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
