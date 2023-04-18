using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Indagro.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
//using Indagro.DAL.Implementacion;
//using Indagro.DAL.Interfaces;
//using Indagro.BLL.Implementacion;
//using Indagro.BLL.Interfaces;

namespace Indagro.IOC
{
    public static class Dependencia
    {

        public static void InyectarDependencia (this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<IndagroContext> (options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CadenaSQL"));
            });
        }

    }
}
