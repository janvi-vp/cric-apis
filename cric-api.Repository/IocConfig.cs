using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace cric_api.Repository
{
    public class IocConfig
    {
        public static void ConfigureService(ref IServiceCollection services, string connectionString)
        {
            Models.IocConfig.ConfigureService(ref services, connectionString);
            services.AddTransient<IPlayerRepository, PlayerRepository>();
        }
    }
}