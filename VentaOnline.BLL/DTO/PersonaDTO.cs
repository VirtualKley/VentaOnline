using System;
using System.Collections.Generic;

namespace VentaOnline.BLL.DTO;

public partial class PersonaDTO
{
    public int IdPersona { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Celular { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<VentaDTO> Venta { get; set; } = new List<VentaDTO>();
}
