using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VentaOnline.UI.Models;

public partial class PersonaViewModel
{
    public int IdPersona { get; set; }

    [Required]
    [Display(Name = "Nombre:")]
    public string Nombre { get; set; } = null!;

    [Required]
    [Display(Name = "Celular:")]
    public string? Celular { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<VentaViewModel> Venta { get; set; } = new List<VentaViewModel>();

    public string ObtenerVentas(ICollection<VentaViewModel> ventas)
    {
        var FullVentas = "";
        var fecha = DateTime.Now.Date.AddDays(-1);
        foreach (var venta in ventas)
        {
            if (venta.Estado == true && venta.FechaVenta >= fecha)
            {
                FullVentas += venta.Descripcion;
                if (!(ventas.Last().IdVenta == venta.IdVenta))
                {
                    FullVentas += ", ";
                }
            }
        }
        return FullVentas;
    }
}
