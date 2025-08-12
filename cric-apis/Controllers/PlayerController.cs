using Microsoft.AspNetCore.Mvc;
using cric_api.Services;
using cric_api.Services.Interfaces;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.Utilities;

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
        [Route("getall")]
        public async Task<IActionResult> GetAll([FromQuery]GetPlayersRequestModel request)
        {
            var players = await _service.GetPlayers(request);
            return Ok(ApiResponse<object>.Ok(players));
        }

        [HttpGet]
        [Route("getbyid")]

        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var player = await _service.GetPlayerById(id);
            return Ok(ApiResponse<object>.Ok(player));
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddPlayer([FromBody] CreatePlayer player)
        {
            var newPlayer = await _service.AddPlayer(player);
            return Ok(ApiResponse<object>.Ok(newPlayer));
        }

        [HttpPut]
        [Route("edit/{id}")]

        public async Task<IActionResult> EditPlayer([FromRoute] int id, [FromBody] EditPlayer editPlayer)
        {
            var editedPlayer = await _service.EditPlayer(editPlayer, id);
            return Ok(ApiResponse<object>.Ok(editedPlayer));
        }

        [HttpDelete]
        [Route("delete/{id}")]

        public async Task<IActionResult> DeletePlayer([FromRoute] int id)
        {
            await _service.DeletePlayer(id);
            return Ok(ApiResponse<object>.Ok("Player has been Deleted!"));
        }
    }
}