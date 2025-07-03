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

    [HttpPost]
    public IActionResult InsertMarkers([FromBody] IEnumerable<MarkerDto> markersDtos)
    {
        if (markersDtos == null || !markersDtos.Any())
        {
            return BadRequest(new { message = "No se proporcionaron marcadores." });
        }

        _mapper.InsertMarkers(markersDtos);
        return Ok(new { message = "Marcadores insertados correctamente." });
    }
}
