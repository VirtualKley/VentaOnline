using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VentaOnline.BLL.DTO;
using VentaOnline.BLL.Interfaces;
using VentaOnline.DAL.Entidades;
using VentaOnline.UI.Models;

namespace VentaOnline.UI.Controllers
{
    public class VentaController : Controller
    {
        private readonly IVentaServicio _ventaServicio;
        private readonly IPersonaServicio _personaServicio;

        public VentaController(IVentaServicio ventaServicio, IPersonaServicio personaServicio)
        {
            _ventaServicio = ventaServicio;
            _personaServicio = personaServicio;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Ventas";
            return View();
        }

        public async Task<IActionResult> ObtenerFormVenta()
        {
            var personas = await _personaServicio.ObtenerPersonas();
            ViewData["Personas"] = new SelectList(personas, "IdPersona", "Nombre", personas.OrderByDescending(p => p.IdPersona).First().IdPersona);
            return PartialView("_RegistrarVenta");
        }

        public async Task<IActionResult> ObtenerVentas()
        {
            var ventas = await _ventaServicio.ObtenerVentas();
            return PartialView("_ListaVenta", ventas.Select(venta => CrearVentaDtoToViewModel(venta)).ToList());
        }

        [HttpPost]
        public void Create(VentaViewModel venta)
        {
            var ventaDTO = CrearVentaViewModelToDto(venta);
            _ventaServicio.CrearVenta(ventaDTO);
        }

        [HttpPost]
        public void Delete(int idVenta)
        {
            _ventaServicio.EliminarVenta(idVenta);
        }

        public IActionResult ObtenerTotalVenta()
        {
            var ventaDTO = _ventaServicio.ObtenerVentasPorPersona();
            return PartialView("_VentaTotales", ventaDTO.Select(venta => CrearVentaDtoToViewModel(venta)).OrderByDescending(v => v.Total).ToList());
        }


        private VentaViewModel CrearVentaDtoToViewModel(VentaDTO venta)
        {
            return new VentaViewModel
            {
                IdVenta = venta.IdVenta,
                IdPersona = venta.IdPersona,
                Descripcion = venta.Descripcion,
                Cantidad = venta.Cantidad,
                Total = venta.Total,
                FechaVenta = venta.FechaVenta,
                Persona = CrearPersonaDtoToViewModel(venta.Persona)
            };
        }

        private PersonaViewModel CrearPersonaDtoToViewModel(PersonaDTO persona)
        {
            return new PersonaViewModel
            {
                IdPersona = persona.IdPersona,
                Nombre = persona.Nombre,
                Celular = persona.Celular,
            };
        }

        private VentaDTO CrearVentaViewModelToDto(VentaViewModel venta)
        {
            return new VentaDTO
            {
                IdVenta = venta.IdVenta,
                IdPersona = venta.IdPersona,
                Descripcion = venta.Descripcion,
                Cantidad = venta.Cantidad,
                Total = decimal.Parse(venta.TotalFloat),
                FechaVenta = venta.FechaVenta,
                //Persona = CrearPersonaViewModelToDto(venta.Persona)
            };
        }

        private PersonaDTO CrearPersonaViewModelToDto(PersonaViewModel persona)
        {
            return new PersonaDTO
            {
                IdPersona = persona.IdPersona,
                Nombre = persona.Nombre,
                Celular = persona.Celular,
            };
        }
    }
}
