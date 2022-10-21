using Microsoft.EntityFrameworkCore;
using Rehber.Context;
using Rehber.DataAccess.Interfaces;
using Rehber.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Database baðlantýsý tanýmlanýr
builder.Services.AddDbContext<ProjectContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.UseLazyLoadingProxies(true);

});

builder.Services.AddScoped<IEmailDAL, EmailRepository>();
builder.Services.AddScoped<IPersonDAL, PersonRepository>();
builder.Services.AddScoped<ILocationDAL, LocationRepository>();
builder.Services.AddScoped<IPhoneNumberDAL, PhoneNumberRepository>();

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
