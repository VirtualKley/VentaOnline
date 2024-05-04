using Microsoft.EntityFrameworkCore;
using VentaOnline.DAL.Contexto;
using VentaOnline.DAL.Entidades;
using VentaOnline.DAL.Interfaces;

namespace VentaOnline.DAL.Repositories
{
    public class VentaRepositorio : IVentaRepositorio
    {
        private readonly DbVentaContext _dbVentaContext;

        public VentaRepositorio(DbVentaContext dbVentaContext)
        {
            _dbVentaContext = dbVentaContext;
        }

        public async Task<IEnumerable<Venta>> ObtenerVentas()
        {
            return await _dbVentaContext.Venta.Include(p => p.Persona).Where(v => v.Estado == true && v.FechaVenta >= DateTime.Now.Date.AddDays(-1)).OrderByDescending(v => v.FechaVenta).ToListAsync();
        }

        public Venta ObtenerVenta(int id)
        {
            return _dbVentaContext.Venta.Include(p => p.Persona).First(v => v.IdVenta == id);
        }

        public int CrearVenta(Venta venta)
        {
            _dbVentaContext.AddAsync(venta);
            return _dbVentaContext.SaveChanges();
        }

        public async Task<int> ActualizarVenta(Venta venta)
        {
            venta.FechaModificacion = DateTime.Now;
            _dbVentaContext.Update(venta);
            return await _dbVentaContext.SaveChangesAsync();
        }

        public int EliminarVenta(int id)
        {
            var venta = ObtenerVentaDB(id);
            venta.Estado = false;
            venta.FechaModificacion = DateTime.Now;

            _dbVentaContext.Entry(ObtenerVentaDB(venta.IdVenta)).CurrentValues.SetValues(venta);
            return _dbVentaContext.SaveChanges();
        }

        private Venta ObtenerVentaDB(int id)
        {
            return _dbVentaContext.Venta.Find(id);
        }

        public IEnumerable<Venta> ObtenerVentasPorPersona()
        {
            var ventasPorPersona = _dbVentaContext.Venta;

            return ventasPorPersona;
        }
    }
}
