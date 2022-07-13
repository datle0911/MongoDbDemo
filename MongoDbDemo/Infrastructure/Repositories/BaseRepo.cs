namespace MongoDbDemo.Infrastructure.Repositories;

public class BaseRepo
{
    protected readonly IMongoCollection<Movie> _movies;
    protected readonly IMongoCollection<Ticket> _tickets;

    public BaseRepo(IOptions<DbSetMovies> movie, IOptions<DbSetTickets> ticket)
    {
        // Create Client
        var movieClient = new MongoClient(movie.Value.ConnectionString);
        var ticketClient = new MongoClient(ticket.Value.ConnectionString);

        // Set DbContext
        _movies = movieClient
            .GetDatabase(movie.Value.DatabaseName)
            .GetCollection<Movie>(movie.Value.CollectionName);
        _tickets = ticketClient
            .GetDatabase(ticket.Value.DatabaseName)
            .GetCollection<Ticket>(ticket.Value.CollectionName);
    }
}
