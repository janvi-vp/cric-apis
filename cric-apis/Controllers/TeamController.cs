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
    [Route("cric_apis/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _service;

        public TeamController(ITeamService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll([FromQuery] GetTeamsRequestModel request)
        {
            var teams = await _service.GetTeams(request);
            return Ok(ApiResponse<object>.Ok(teams));
        }
    }
}