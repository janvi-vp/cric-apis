using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.DTOs.Request;

namespace cric_api.Services.Interfaces
{
    public interface IMatchService
    {
        Task ScheduleMatch(ScheduleMatch match);
    }
}