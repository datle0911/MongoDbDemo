namespace MongoDbDemo.Services;

public class TicketService
{
    protected readonly TicketRepo _ticketRepo;
    protected readonly MovieRepo _movieRepo;

    public TicketService(TicketRepo ticketRepo, MovieRepo movieRepo)
    {
        _ticketRepo = ticketRepo;
        _movieRepo = movieRepo;
    }

    public async Task<List<Ticket>> GetAll()
    {
        return await _ticketRepo.Get();
    }

    public async Task<Ticket> Post(Ticket ticket)
    {
        var movie = _movieRepo.FindMovieAsync(ticket.MovieId).Result;
        if(movie is null)
        {
            return null;
        }

        var result = await _ticketRepo.Create(ticket);

        return result;
    }
}
