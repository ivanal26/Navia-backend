namespace Navia_Backend.Controllers.Markers;
using Navia_Backend.Data;
using Navia_Backend.Data.Models;

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

    public void InsertMarkers(IEnumerable<MarkerDto> markersDtos)
    {
        var markers = markersDtos.Select(dto => new Marker
        {
            Descripcion = dto.Descripcion,
            Latitud = dto.Latitud,
            Longitud = dto.Longitud,
            Nombre = dto.Nombre,
            Valoracion = dto.Valoracion,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = dto.CreatedBy,
            ChangedAt = DateTime.UtcNow,
            ChangedBy = dto.ChangedBy
        }).ToList();

        _context.Markers.AddRange(markers);
        _context.SaveChanges();
    }
}
