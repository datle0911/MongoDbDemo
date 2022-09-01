var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

// Database set
builder.Services.Configure<DbSetMovies>(cfg =>
{
    cfg.ConnectionString = config.GetSection("MongoDbSettings:ConnectionString").Value;
    cfg.DatabaseName = config.GetSection("MongoDbSettings:DatabaseName").Value;
    cfg.CollectionName = config.GetSection("MongoDbSettings:CollectionName:Movies").Value;
});
builder.Services.Configure<DbSetTickets>(cfg =>
{
    cfg.ConnectionString = config.GetSection("MongoDbSettings:ConnectionString").Value;
    cfg.DatabaseName = config.GetSection("MongoDbSettings:DatabaseName").Value;
    cfg.CollectionName = config.GetSection("MongoDbSettings:CollectionName:Tickets").Value;
});

// Services lifetime
builder.Services.AddTransient<MovieService>();
builder.Services.AddTransient<TicketService>();

// Repos lifetime
builder.Services.AddTransient<MovieRepo>();
builder.Services.AddTransient<TicketRepo>();

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
