using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaOnline.BLL.DTO;
using VentaOnline.DAL.Entidades;

namespace VentaOnline.BLL.Interfaces
{
    public interface IPersonaServicio
    {
        Task<IEnumerable<PersonaDTO>> ObtenerPersonas();
        PersonaDTO ObtenerPersona(int id);
        Task<int> CrearPersona(PersonaDTO persona);
        Task<int> ActualizarPersona(PersonaDTO persona);
        Task<int> EliminarPersona(int id);
    }
}
