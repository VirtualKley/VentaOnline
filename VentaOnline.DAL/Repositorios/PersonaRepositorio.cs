using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaOnline.DAL.Contexto;
using VentaOnline.DAL.Entidades;
using VentaOnline.DAL.Interfaces;

namespace VentaOnline.DAL.Repositories
{
    public class PersonaRepositorio : IPersonaRepositorio
    {
        private readonly DbVentaContext _dbVentaContexto;

        public PersonaRepositorio(DbVentaContext dbVentaContexto)
        {
            _dbVentaContexto = dbVentaContexto;
        }

        public async Task<IEnumerable<Persona>> ObtenerPersonas()
        {
            return await _dbVentaContexto.Personas.Include(p => p.Venta).Where(p => p.Estado == true).OrderBy(p => p.Nombre).ToListAsync();
        }

        public Persona ObtenerPersona(int id)
        {
            return _dbVentaContexto.Personas.Find(id);
        }

        public async Task<int> CrearPersona(Persona persona)
        {
            await _dbVentaContexto.Personas.AddAsync(persona);
            return await _dbVentaContexto.SaveChangesAsync();
        }

        public async Task<int> ActualizarPersona(Persona persona)
        {
            var personaDB = ObtenerPersona(persona.IdPersona);
            persona.Estado = personaDB.Estado;
            persona.FechaModificacion = DateTime.Now;
            _dbVentaContexto.Entry(personaDB).CurrentValues.SetValues(persona);
            return await _dbVentaContexto.SaveChangesAsync();
        }

        public async Task<int> EliminarPersona(int id)
        {
            var persona = ObtenerPersona(id);
            persona.Estado = false;
            persona.FechaModificacion = DateTime.Now;
            _dbVentaContexto.Entry(ObtenerPersona(persona.IdPersona)).CurrentValues.SetValues(persona);
            //_dbVentaContexto.Update(persona);
            return await _dbVentaContexto.SaveChangesAsync();
        }
    }
}
