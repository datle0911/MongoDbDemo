namespace MongoDbDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : Controller
{
    protected readonly TicketService _ticketService;
    public TicketsController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _ticketService.GetAll();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Ticket ticket)
    {
        var result = await _ticketService.Post(ticket);
        if (result is null)
        {
            return BadRequest("Failure");
        }
        return Ok("Success");
    }
}
