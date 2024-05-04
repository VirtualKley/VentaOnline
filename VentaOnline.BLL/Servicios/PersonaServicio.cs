using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaOnline.BLL.DTO;
using VentaOnline.BLL.Interfaces;
using VentaOnline.DAL.Interfaces;
using VentaOnline.DAL.Entidades;

namespace VentaOnline.BLL.Servicios
{
    public class PersonaServicio : IPersonaServicio
    {
        private readonly IPersonaRepositorio _personaRepositorio;

        public PersonaServicio(IPersonaRepositorio personaRepositorio)
        {
            _personaRepositorio = personaRepositorio;
        }

        public async Task<IEnumerable<PersonaDTO>> ObtenerPersonas()
        {
            var personas = await _personaRepositorio.ObtenerPersonas();
            return personas.Select(persona => CrearPersonaRepoToDto(persona)).ToList();
        }

        public PersonaDTO ObtenerPersona(int id)
        {
            var persona = _personaRepositorio.ObtenerPersona(id);
            return CrearPersonaRepoToDto(persona);
        }

        public async Task<int> CrearPersona(PersonaDTO persona)
        {
            return await _personaRepositorio.CrearPersona(CrearPersonaDtoToRepo(persona));
        }

        public async Task<int> ActualizarPersona(PersonaDTO persona)
        {
            ValidarExistenciaPersona(persona.IdPersona);
            return await _personaRepositorio.ActualizarPersona(CrearPersonaDtoToRepo(persona));
        }

        public async Task<int> EliminarPersona(int id)
        {
            ValidarExistenciaPersona(id);
            return await _personaRepositorio.EliminarPersona(id);
        }

        private async void ValidarExistenciaPersona(int idPersona)
        {
            if (_personaRepositorio.ObtenerPersona(idPersona) == null) throw new Exception("El ID de la persona no consta en la base de datos");
        }

        private Persona CrearPersonaDtoToRepo(PersonaDTO personaDTO)
        {
            return new Persona
            {
                IdPersona = personaDTO.IdPersona,
                Nombre = personaDTO.Nombre,
                Celular = personaDTO.Celular,
            };
        }

        private PersonaDTO CrearPersonaRepoToDto(Persona persona)
        {
            return new PersonaDTO
            {
                IdPersona = persona.IdPersona,
                Nombre = persona.Nombre,
                Celular = persona.Celular,
                Venta = CrearVentaRepoToDto(persona.Venta)
            };
        }

        private ICollection<VentaDTO> CrearVentaRepoToDto(ICollection<Venta> venta)
        {
            return venta.Where(v => v.Estado == true).Select(v =>
                new VentaDTO
                {
                    IdVenta = v.IdVenta,
                    IdPersona = v.IdPersona,
                    Descripcion = v.Descripcion,
                    Cantidad = v.Cantidad,
                    Total = v.Total,
                    FechaVenta = v.FechaVenta,
                    Estado = v.Estado
                }
            ).ToList();
        }
    }
}
