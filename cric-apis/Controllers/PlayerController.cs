using Microsoft.AspNetCore.Mvc;
using cric_api.Services;
using cric_api.Services.Interfaces;

namespace cric_apis.Controllers
{
    [Route("cric_apis/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _service;

        public PlayerController(IPlayerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getbyteam/{teamId}")]
        public async Task<IActionResult> GetAllPlayersByTeam([FromRoute] Guid teamId)
        {
            var players = await _service.GetAllPlayersByTeamAsync(teamId);

            return Ok(players);
        } 
        
    }
}