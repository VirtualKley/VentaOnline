using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaOnline.DAL.Entidades;

namespace VentaOnline.DAL.Interfaces
{
    public interface IPersonaRepositorio
    {
        Task<IEnumerable<Persona>> ObtenerPersonas();
        Persona ObtenerPersona(int id);
        Task<int> CrearPersona(Persona persona);
        Task<int> ActualizarPersona(Persona persona);
        Task<int> EliminarPersona(int id);
    }
}
