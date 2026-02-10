using ASPNETCoreWebAPI_CQRS.Application.Repositories;
using ASPNETCoreWebAPI_CQRS.Application.Services;
using ASPNETCoreWebAPI_CQRS.Infrastructure.Repositories;
using HelpDesk.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// 1 Swagger
builder.Services.AddSwaggerGen();

// DI Services
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();

var app = builder.Build();

app.UseAuthorization();

// Configure the HTTP request pipeline.
// 2 use Middleware after app.UseAuthorization()
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HelpDesk API V1");
        c.RoutePrefix = string.Empty; // Swagger http://localhost:8000/ 
    });
}

// /wwwroot
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();
