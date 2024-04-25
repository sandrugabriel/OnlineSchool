using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using OnlineSchool.Books.Repository;
using OnlineSchool.Books.Repository.interfaces;
using OnlineSchool.Books.Services;
using OnlineSchool.Books.Services.interfaces;
using OnlineSchool.Data;
using OnlineSchool.Students.Repository;
using OnlineSchool.Students.Repository.interfaces;
using OnlineSchool.Students.Services;
using OnlineSchool.Students.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositoryStudent, RepositoryStudent>();
builder.Services.AddScoped<IQueryServiceStudent, QueryServiceStudents>();
builder.Services.AddScoped<ICommandServiceStudent, CommandServiceStudents>();


builder.Services.AddScoped<IRepositoryBook, RepositoryBook>();
builder.Services.AddScoped<IQueryServiceBook, QueryServiceBook>();
builder.Services.AddScoped<ICommandServiceBook, CommandServiceBook>();


builder.Services.AddDbContext<AppDbContext>(op => op.UseMySql(builder.Configuration.GetConnectionString("Default")!,
    new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb.AddMySql5().WithGlobalConnectionString(builder.Configuration.GetConnectionString("Default"))
    .ScanIn(typeof(Program).Assembly).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole());

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}

    app.Run();
