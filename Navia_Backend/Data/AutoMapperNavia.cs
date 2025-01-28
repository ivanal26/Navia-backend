namespace Navia_Backend.Data;

using AutoMapper;
using Navia_Backend.Controllers.Markers;
using Navia_Backend.Data.Models;

public class AutoMapperNavia : Profile
{
    public AutoMapperNavia()
    {
        CreateMap<Marker, MarkerDto>();
    }
}
