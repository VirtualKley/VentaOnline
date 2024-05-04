using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaOnline.BLL.DTO;
using VentaOnline.BLL.Interfaces;
using VentaOnline.DAL.Contexto;
using VentaOnline.DAL.Entidades;
using VentaOnline.DAL.Interfaces;

namespace VentaOnline.BLL.Servicios
{
    public class VentaServicio : IVentaServicio
    {
        private readonly IVentaRepositorio _ventaRepositorio;
        private readonly IPersonaRepositorio _personaRepositorio;

        public VentaServicio(IVentaRepositorio ventaRepositorio, IPersonaRepositorio personaRepositorio)
        {
            _ventaRepositorio = ventaRepositorio;
            _personaRepositorio = personaRepositorio;
        }

        public async Task<IEnumerable<VentaDTO>> ObtenerVentas()
        {
            var ventas = await _ventaRepositorio.ObtenerVentas();
            return ventas.Select(persona => CrearVentaRepoToDto(persona));
        }

        public VentaDTO ObtenerVenta(int id)
        {
            var ventas = _ventaRepositorio.ObtenerVenta(id);
            return CrearVentaRepoToDto(ventas);
        }

        public int CrearVenta(VentaDTO venta)
        {
            return _ventaRepositorio.CrearVenta(CrearVentaDtoToRepo(venta));
        }

        public async Task<int> ActualizarVenta(VentaDTO venta)
        {
            ValidarExistenciaVenta(venta.IdVenta);
            return await _ventaRepositorio.ActualizarVenta(CrearVentaDtoToRepo(venta));
        }

        public int EliminarVenta(int id)
        {
            ValidarExistenciaVenta(id);
            return _ventaRepositorio.EliminarVenta(id);
        }

        private void ValidarExistenciaVenta(int idVenta)
        {
            if (_ventaRepositorio.ObtenerVenta(idVenta) == null) throw new Exception("El ID de la venta no consta en la base de datos");
        }

        public IEnumerable<VentaDTO> ObtenerVentasPorPersona()
        {
            var ventas = _ventaRepositorio.ObtenerVentasPorPersona();

            var ventasPorPersona = ventas
                .Where(v => v.Estado == true && v.FechaVenta >= DateTime.Now.Date.AddDays(-1))
                .GroupBy(v => v.IdPersona)
                .Select(g => new VentaDTO
                {
                    IdPersona = g.FirstOrDefault().IdPersona,
                    Cantidad = g.Count(),
                    Total = g.Sum(v => v.Total),
                    Persona = CrearPersonaRepoToDto(_personaRepositorio.ObtenerPersona(g.FirstOrDefault().IdPersona))
                })
                .ToList();

            return ventasPorPersona;
        }

        private Venta CrearVentaDtoToRepo(VentaDTO venta)
        {
            return new Venta
            {
                IdVenta = venta.IdVenta,
                IdPersona = venta.IdPersona,
                Descripcion = venta.Descripcion,
                Cantidad = venta.Cantidad,
                Total = venta.Total
            };
        }

        private VentaDTO CrearVentaRepoToDto(Venta venta)
        {
            return new VentaDTO
            {
                IdVenta = venta.IdVenta,
                IdPersona = venta.IdPersona,
                Descripcion = venta.Descripcion,
                Cantidad = venta.Cantidad,
                Total = venta.Total,
                FechaVenta = venta.FechaVenta,
                Persona = CrearPersonaRepoToDto(venta.Persona)
            };
        }

        private PersonaDTO CrearPersonaRepoToDto(Persona persona)
        {
            return new PersonaDTO
            {
                IdPersona = persona.IdPersona,
                Nombre = persona.Nombre,
                Celular = "+593" + persona.Celular,
            };
        }
    }
}
