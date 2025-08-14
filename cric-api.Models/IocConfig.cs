using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace cric_api.Models
{
    public class IocConfig
    {
        public static void ConfigureService(ref IServiceCollection services, string connectionString)
        {

            services.AddDbContext<CricContext>(options => options.UseSqlServer(connectionString));

        }
    }
}