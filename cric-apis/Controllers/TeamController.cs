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

        [HttpGet]
        [Route("getbyid")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var team = await _service.GetTeamById(id);
            return Ok(ApiResponse<object>.Ok(team));
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddPlayer([FromBody] CreateTeam team)
        {
            var newTeam = await _service.AddTeam(team);
            return Ok(ApiResponse<object>.Ok(newTeam));
        }

        [HttpPost]
        [Route("addplayertoteam")]
        public async Task<IActionResult> AddPlayerToTeam([FromQuery] int teamId, [FromQuery] int playerId)
        {
            var newTeamPlayer = await _service.AddPlayerToTeam(teamId, playerId);
            return Ok(ApiResponse<object>.Ok(newTeamPlayer));
        }

        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditPlayer([FromRoute] int id, [FromBody] string name)
        {
            var editedTeam = await _service.EditTeam(id, name);
            return Ok(ApiResponse<object>.Ok(editedTeam));
        }

        [HttpDelete]
        [Route("delete/{id}")]

        public async Task<IActionResult> DeleteTeam([FromRoute] int id)
        {
            await _service.DeleteTeam(id);
            return Ok(ApiResponse<object>.Ok("Team has been Deleted!"));
        }
        
        [HttpDelete]
        [Route("removeplayerfromteam")]

        public async Task<IActionResult> RemovePlayerFromTeam([FromQuery] int teamId, [FromQuery] int playerId)
        {
            await _service.RemovePlayerFromTeam(teamId, playerId);
            return Ok(ApiResponse<object>.Ok("Player has been removed from the team!"));
        }
    }
}