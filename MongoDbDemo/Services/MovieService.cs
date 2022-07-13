namespace MongoDbDemo.Services;

public class MovieService
{
    protected readonly MovieRepo _movieRepo;
    public MovieService(MovieRepo movieRepo)
    {
        _movieRepo = movieRepo;
    }

    public async Task<List<Movie>> GetAll()
    {
        return await _movieRepo.Get();
    }

    public async Task<Movie> Post(Movie movie)
    {
        var result = await _movieRepo.Create(movie);

        return result;
    }
}
