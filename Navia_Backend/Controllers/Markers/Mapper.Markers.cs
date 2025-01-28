namespace Navia_Backend.Controllers.Markers;
using Navia_Backend.Data;

public class MarkersMapper
{
    private readonly AppDbContext _context;

    public MarkersMapper(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<MarkerDto> Get()
    {
        return _context.Markers
                .Select(marker => new MarkerDto
                {
                    Id = marker.Id,
                    Descripcion = marker.Descripcion,
                    Latitud = marker.Latitud,
                    Longitud = marker.Longitud,
                    Nombre = marker.Nombre,
                    Valoracion = marker.Valoracion,
                    CreatedAt = marker.CreatedAt,
                    CreatedBy = marker.CreatedBy,
                    ChangedAt = marker.ChangedAt,
                    ChangedBy = marker.ChangedBy
                })
                .ToList();
    }
}
