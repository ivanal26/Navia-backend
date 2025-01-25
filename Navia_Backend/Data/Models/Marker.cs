using System;
using System.Collections.Generic;

namespace Navia_Backend.Data.Models;

public partial class Marker
{
    public int Id { get; set; }

    public string? Descripcion { get; set; }

    public double Latitud { get; set; }

    public double Longitud { get; set; }

    public string Nombre { get; set; } = null!;

    public int? Valoracion { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ChangedAt { get; set; }

    public string? ChangedBy { get; set; }
}
