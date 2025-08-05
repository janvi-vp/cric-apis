using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_apis.Repository;
using cric_apis.Data;
using cric_apis.Models;
using Microsoft.AspNetCore.Mvc;

namespace cric_apis.Controllers
{
    [Route("cric_apis/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly CricContext _context;

        private readonly PlayerRepository _playerRepo;

        public PlayerController(CricContext context, PlayerRepository playerRepo)
        {
            _context = context;
            _playerRepo = playerRepo;
        }

        [HttpGet]
        [Route("{teamId}")]
        public async Task<IActionResult> GetAllPlayersByTeam([FromRoute] Guid teamId)
        {
            var players = await _playerRepo.GetAllPlayersByTeamAsync(teamId);

            return Ok(players);
        } 
        
    }
}