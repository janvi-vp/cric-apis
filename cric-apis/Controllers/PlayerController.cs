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
        [Route("GetPlayers")]
        public async Task<IActionResult> GetPlayers([FromQuery]GetPlayersRequestModel request)
        {
            var players = await _service.GetPlayers(request);
            return Ok(ApiResponse<object>.Ok(players));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlayers(int pageNumber, int pageSize)
        {
            try
            {
                var players = await _service.GetAllPlayers(pageNumber, pageSize);
                return Ok(ApiResponse<object>.Ok(players));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
        }

        [HttpGet]
        [Route("getbyfilter")]
        public async Task<IActionResult> GetAllPlayersByFilter([FromQuery] string? firstName = null, [FromQuery] string? lastName = null, [FromQuery] string? email = null)
        {
            try
            {
                var players = await _service.GetAllPlayersByFilter(firstName, lastName, email);
                return Ok(ApiResponse<object>.Ok(players));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
        }

        [HttpGet]
        [Route("getbysorting")]

        public async Task<IActionResult> GetAllPlayersBySorting([FromQuery] string? sortingParam = null)
        {
            try
            {
                var players = await _service.GetALlPlayersBySorting(sortingParam);
                return Ok(ApiResponse<object>.Ok(players));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
        }

        [HttpGet]
        [Route("getbyid")]

        public async Task<IActionResult> GetPlayerById([FromQuery] int id)
        {
            try
            {
                var player = await _service.GetPlayerById(id);
                return Ok(ApiResponse<object>.Ok(player));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
        }

        [HttpPost]

        public async Task<IActionResult> AddPlayer([FromBody] CreatePlayer player)
        {
            try
            {
                await _service.AddPlayer(player);
                return Ok(ApiResponse<object>.Ok("Book is Added!"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
        }

        [HttpPut]
        [Route("editplayer/{id}")]

        public async Task<IActionResult> EditPlayer([FromRoute] int id, [FromBody] EditPlayer editPlayer)
        {
            try
            {
                await _service.EditPlayer(editPlayer, id);
                return Ok(ApiResponse<object>.Ok("Player is Edited!"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
        }

        [HttpDelete]
        [Route("deleteplayer/{id}")]

        public async Task<IActionResult> DeletePlayer([FromRoute] int id)
        {
            try
            {
                await _service.DeletePlayer(id);
                return Ok(ApiResponse<object>.Ok("Player has been Deleted!"));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<object>.Fail(ex.Message));
            }
        }
    }
}