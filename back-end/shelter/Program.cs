
using Microsoft.EntityFrameworkCore;
using shelter.DataBaseContext.PetDbContext;
using shelter.DataBaseContext.ShelterDbContext;
using shelter.DataBaseContext.UserDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDbContext<UserDbContext>(options =>
{
    var connectionString = configuration.GetConnectionString("UserDataConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<PetDbContext>(options =>
{
    var connectionString = configuration.GetConnectionString("PetDataConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<ShelterDbContext>(options =>
{
    var connectionString = configuration.GetConnectionString("ShelterDataConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

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

app.UseCors("AllowAnyOrigin");

app.Run();
