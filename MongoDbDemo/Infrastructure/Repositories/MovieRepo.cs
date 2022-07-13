namespace MongoDbDemo.Infrastructure.Repositories;

public class MovieRepo : BaseRepo
{
    public MovieRepo(IOptions<DbSetMovies> movie, IOptions<DbSetTickets> ticket) : base(movie, ticket)
    {
    }

    public async Task<List<Movie>> Get()
    {
        return await _movies.Find(_ 
            => true)
            .ToListAsync();
    }

    public async Task<Movie> FindMovieAsync(int id)
    {
        return await _movies.Find(m
            => m.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Movie> Create(Movie movie)
    {
        await _movies
            .InsertOneAsync(movie);
        
        return movie;
    }
}
