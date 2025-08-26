using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.DTOs.Response;

namespace cric_api.Services.Interfaces
{
    public interface IMatchService
    {
        Task<MatchViewModel> ScheduleMatch(ScheduleMatch match);
    }
}