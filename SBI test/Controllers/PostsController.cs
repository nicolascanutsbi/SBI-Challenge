using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<Salida>> GetPostById([FromQuery] int id)
    {
        var query = new GetPostQuery(id);
        var salida = await _mediator.Send(query);

        if (salida == null)
        {
            return NotFound();
        }

        return Ok(salida); // Devolver la clase Salida como JSON
    }
}
