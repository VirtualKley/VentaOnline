using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VentaOnline.BLL.Interfaces;
using VentaOnline.BLL.Servicios;
using VentaOnline.DAL.Contexto;
using VentaOnline.DAL.Interfaces;
using VentaOnline.DAL.Repositories;

namespace VentaOnline.IOC.DbDepdencyInjection
{
    public class DependencyInjection
    {
        public static void AddServiceDbContext(IServiceCollection services, string? stringConnection)
        {
            services.AddDbContext<DbVentaContext>(options => options.UseSqlServer(stringConnection));
        }

        public static void AddServiceScoped(IServiceCollection services)
        {
            services.AddScoped<IPersonaServicio, PersonaServicio>();
            services.AddScoped<IVentaServicio, VentaServicio>();
        }

        public static void AddRepositoryScoped(IServiceCollection services)
        {
            services.AddScoped<IPersonaRepositorio, PersonaRepositorio>();
            services.AddScoped<IVentaRepositorio, VentaRepositorio>();
        }
    }
}
