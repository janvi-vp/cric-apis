using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.DTOs.Request;
using cric_api.Repository.Interfaces;
using cric_api.Services.Interfaces;

namespace cric_api.Services.Services
{
    public class MatchService : IMatchService
    {
        private IMatchRepository _repository;

        public MatchService(IMatchRepository repository)
        {
            _repository = repository;
        }

        public async Task ScheduleMatch(ScheduleMatch match)
        {
            await _repository.ScheduleMatch(match);
        }
    }
}