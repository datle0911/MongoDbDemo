namespace MongoDbDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : Controller
{
    private readonly MovieService _movieService;
    public MoviesController(MovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _movieService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Movie movie)
    {
        var result = await _movieService.Post(movie);
        if(result is null)
        {
            return BadRequest("Failure");
        }
        return Ok("Success");
    }
}
