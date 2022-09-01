var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

#region Database set
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
#endregion

// Services lifetime
builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<TicketService>();

// Repos lifetime
builder.Services.AddScoped<MovieRepo>();
builder.Services.AddScoped<TicketRepo>();

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
