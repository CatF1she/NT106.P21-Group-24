using MongoDB.Driver;
using Do_An_Server.Controllers;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var client = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
    return client.GetDatabase("Do-An-Server");
});
builder.Services.AddScoped<MongoDBContext>();
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
public class MongoDBContext
{
    private readonly IMongoDatabase _database;
    public MongoDBContext(IConfiguration configuration) 
    {
        var client = new MongoClient(configuration.GetSection("MongoDB:ConnectionString").Value);
        _database = client.GetDatabase("Do-An-Server");
    }
    public IMongoCollection<Users> Users => _database.GetCollection<Users>("Users");

}