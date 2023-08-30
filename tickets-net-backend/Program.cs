using Microsoft.EntityFrameworkCore;
using NLog.Web;
using tickets_net_backend.Middlewares;
using tickets_net_backend.Models;
using tickets_net_backend.Repositories;
using tickets_net_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TicketsSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TicketsDatabase")));

builder.Services.AddTransient<IEventRepository, EventRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ITicketCategoryRepository, TicketCategoryRepository>();

builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
