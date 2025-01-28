namespace Navia_Backend.Controllers.Markers;
using Microsoft.AspNetCore.Mvc;

[Route("api/markers")]
[ApiController]
public class MarkersController : ControllerBase
{
    private readonly MarkersMapper _mapper;
    public MarkersController(MarkersMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<MarkerDto> Get() => _mapper.Get();
}
