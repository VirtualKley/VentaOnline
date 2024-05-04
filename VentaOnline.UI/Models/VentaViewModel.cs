using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VentaOnline.UI.Models;

public partial class VentaViewModel
{
    public int IdVenta { get; set; }

    [Required]
    [Display(Name = "Cliente")]
    public int IdPersona { get; set; }

    [Required]
    public string Descripcion { get; set; } = null!;

    [Required]
    public int Cantidad { get; set; }

    [Required]
    public decimal Total { get; set; }

    public string TotalFloat { get; set; }

    public DateTime? FechaVenta { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public bool? Estado { get; set; }

    public virtual PersonaViewModel Persona { get; set; } = null!;
}
