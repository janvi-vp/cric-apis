using Microsoft.AspNetCore.Mvc;
using cric_api.Services;

namespace cric_apis.Controllers
{
    [Route("cric_apis/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _service;

        public PlayerController(PlayerService service)
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