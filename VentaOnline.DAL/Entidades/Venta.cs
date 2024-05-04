using System;
using System.Collections.Generic;

namespace VentaOnline.DAL.Entidades;

public partial class Venta
{
    public int IdVenta { get; set; }

    public int IdPersona { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Cantidad { get; set; }

    public decimal Total { get; set; }

    public DateTime? FechaVenta { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public bool? Estado { get; set; }

    public virtual Persona Persona { get; set; } = null!;
}
