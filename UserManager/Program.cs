using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using UserManagerAPI.Middleware;
using UserManagerAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MainDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

//Add services to the container.
builder.Services.AddControllers();
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add DI for user DB service
builder.Services.AddScoped<IUserService, UserService>(); 

var app = builder.Build();

//Add migrations support
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MainDbContext>();
    dbContext.Database.Migrate();
}

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Add API key authorization
//app.UseMiddleware<ApiKeyMiddleware>();
app.UseAuthorization();

//Add logging - one log file per day for requests
app.UseMiddleware<RequestLoggingMiddleware>();

app.MapControllers();

app.Run();
