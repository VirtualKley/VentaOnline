using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaOnline.DAL.Entidades;

namespace VentaOnline.DAL.Interfaces
{
    public interface IVentaRepositorio
    {
        Task<IEnumerable<Venta>> ObtenerVentas();
        Venta ObtenerVenta(int id);
        int CrearVenta(Venta venta);
        Task<int> ActualizarVenta(Venta venta);
        int EliminarVenta(int id);
        IEnumerable<Venta> ObtenerVentasPorPersona();
    }
}
