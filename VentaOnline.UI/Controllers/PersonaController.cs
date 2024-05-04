using Microsoft.AspNetCore.Mvc;
using VentaOnline.BLL.DTO;
using VentaOnline.BLL.Interfaces;
using VentaOnline.DAL.Entidades;
using VentaOnline.UI.Models;

namespace VentaOnline.UI.Controllers
{
    public class PersonaController : Controller
    {
        private readonly IPersonaServicio _personaServicio;

        public PersonaController(IPersonaServicio personaServicio)
        {
            _personaServicio = personaServicio;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Clientes";
            var personas = await _personaServicio.ObtenerPersonas();
            return View(personas.Select(persona => CrearPersonaDtoToViewModel(persona)).ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Title = "Crear Cliente";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonaViewModel persona)
        {
            await _personaServicio.CrearPersona(CrearPersonaViewModelToDto(persona));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var persona = _personaServicio.ObtenerPersona(id);
            return View(CrearPersonaDtoToViewModel(persona));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PersonaViewModel persona)
        {
            if (ModelState.IsValid)
            {
                await _personaServicio.ActualizarPersona(CrearPersonaViewModelToDto(persona));
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int idPersona)
        {
            await _personaServicio.EliminarPersona(idPersona);
            return RedirectToAction(nameof(Index));
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

        private PersonaViewModel CrearPersonaDtoToViewModel(PersonaDTO persona)
        {
            return new PersonaViewModel
            {
                IdPersona = persona.IdPersona,
                Nombre = persona.Nombre,
                Celular = persona.Celular,
                Venta = CrearVentaDtoToViewModel(persona.Venta)
            };
        }

        private ICollection<VentaViewModel> CrearVentaDtoToViewModel(ICollection<VentaDTO> ventas)
        {
            return ventas.Select(venta => new VentaViewModel
            {
                IdVenta = venta.IdVenta,
                IdPersona = venta.IdPersona,
                Descripcion = venta.Descripcion,
                Cantidad = venta.Cantidad,
                Total = venta.Total,
                FechaVenta = venta.FechaVenta,
                Estado = venta.Estado,
            }).ToList();
        }
    }
}
