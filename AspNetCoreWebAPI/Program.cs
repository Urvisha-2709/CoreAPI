using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AspNetCoreWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register ProductService with the dependency injection container
builder.Services.AddSingleton<ProductService>();

// Configure the ConnectionString options
builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection("ConnectionString"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

public class ConnectionString
{
    public string? ProjectConnection { get; set; }
    public string? MyNullableString { get; set; }
    public string MyNonNullableString { get; set; }
}
