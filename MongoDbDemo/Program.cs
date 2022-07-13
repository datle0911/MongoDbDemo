var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

// Database set
builder.Services.Configure<DbSetMovies>(builder.Configuration.GetSection("MongoDbSettings:Movies"));
builder.Services.Configure<DbSetTickets>(builder.Configuration.GetSection("MongoDbSettings:Tickets"));

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
