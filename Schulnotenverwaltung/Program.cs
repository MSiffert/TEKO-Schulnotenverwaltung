using Microsoft.EntityFrameworkCore;
using Schulnotenverwaltung.Data;
using Schulnotenverwaltung.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ClassRepository>();
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<ExamGradesRepository>();
builder.Services.AddScoped<ExamRepository>();

builder.Services.AddDbContext<GradesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
