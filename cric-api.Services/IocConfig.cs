using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Models;
using cric_api.Services.Interfaces;
using cric_api.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace cric_api.Services
{
    public class IocConfig
    {
        public static void ConfigureService(ref IServiceCollection services, string connectionString)
        {
            Repository.IocConfig.ConfigureService(ref services, connectionString);
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IVenueService, VenueService>();
            services.AddTransient<IMatchService, MatchService>();
        }
    }
}