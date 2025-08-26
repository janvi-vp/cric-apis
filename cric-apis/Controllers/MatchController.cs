using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.Utilities;
using cric_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cric_apis.Controllers
{
    [Route("cric_apis/matches")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _service;

        public MatchController(IMatchService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("schedule")]
        public async Task<IActionResult> ScheduleMatch([FromBody] ScheduleMatch match)
        {
            var newMatch = await _service.ScheduleMatch(match);
            return Ok(ApiResponse<object>.Ok(newMatch));
        }

    }
}