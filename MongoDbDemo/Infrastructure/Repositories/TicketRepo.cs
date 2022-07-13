namespace MongoDbDemo.Infrastructure.Repositories;

public class TicketRepo : BaseRepo
{
    public TicketRepo(IOptions<DbSetMovies> movie, IOptions<DbSetTickets> ticket) : base(movie, ticket)
    {
    }

    public async Task<List<Ticket>> Get()
    {
        return await _tickets.Find(_
            => true)
            .ToListAsync();
    }

    public async Task<Ticket> Create(Ticket ticket)
    {
        await _tickets
            .InsertOneAsync(ticket);

        return ticket;
    }
}
