using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaOnline.BLL.DTO;

namespace VentaOnline.BLL.Interfaces
{
    public interface IVentaServicio
    {
        Task<IEnumerable<VentaDTO>> ObtenerVentas();
        VentaDTO ObtenerVenta(int id);
        int CrearVenta(VentaDTO venta);
        Task<int> ActualizarVenta(VentaDTO venta);
        int EliminarVenta(int id);
        IEnumerable<VentaDTO> ObtenerVentasPorPersona();
    }
}
