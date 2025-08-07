using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace cric_api.Services
{
    public class IocConfig
    {
        public static void ConfigureService(ref IServiceCollection services, string connectionString)
        {
            Repository.IocConfig.ConfigureService(ref services, connectionString);
            services.AddTransient<PlayerService, PlayerService>();
        }
    }
}