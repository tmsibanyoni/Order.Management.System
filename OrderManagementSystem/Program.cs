using Microsoft.EntityFrameworkCore;
using Order.Management.Repository.Helpers;
using Order.Management.Repository.Interfaces;
using Order.Management.Repository.Options;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var redisConnectionString = builder.Configuration.GetSection("RedisConfiguration").GetValue<string>("RedisConnectionString");
builder.Services.AddSingleton<string>(redisConnectionString);

builder.Services.AddLogging();

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<ApplicationDbContextHelper>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddTransient<IRedisRepositoryHelper, RedisRepositoryHelper>();
builder.Services.AddTransient<IDiscountHelper, DiscountHelper>();
builder.Services.AddTransient<IOrderHelper, OrderHelper>();
builder.Services.AddTransient<IDomainManager, DomainManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

public partial class Program { }