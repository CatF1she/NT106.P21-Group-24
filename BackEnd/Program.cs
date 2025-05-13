using BackEnd.Hubs;
using BackEnd.Models;
using BackEnd.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Load MongoDBSettings from appsettings.json
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

// Register MongoDB client from configuration
builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var settings = builder.Configuration
        .GetSection("MongoDBSettings")
        .Get<MongoDBSettings>() ?? throw new InvalidOperationException("MongoDBSettings missing.");
    return new MongoClient(settings.ConnectionString);
});

// Register IMongoDatabase (based on settings.DatabaseName)
builder.Services.AddSingleton(sp =>
{
    var settings = builder.Configuration
        .GetSection("MongoDBSettings")
        .Get<MongoDBSettings>()!;
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(settings.DatabaseName);
});

// Register custom services
builder.Services.AddSingleton<GameSessionService>();
builder.Services.AddSingleton<UserService>();
// Register SignalR
builder.Services.AddSignalR();

var app = builder.Build();
app.MapHub<GameHub>("/gamehub"); // This is the endpoint the client will connect to
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
