using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.DTOs.Request;

namespace cric_api.Repository.Interfaces
{
    public interface IMatchRepository
    {
        Task ScheduleMatch(ScheduleMatch match);
    }
}