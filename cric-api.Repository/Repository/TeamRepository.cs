using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Data;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.DTOs.Response;
using cric_api.DTOs.Utilities;
using cric_api.Models;
using cric_api.Models.Models;
using cric_api.Repository.Interfaces;
using cric_api.Repository.Utilities;
using Microsoft.EntityFrameworkCore;

namespace cric_api.Repository.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly CricContext _context;

        public TeamRepository(CricContext context)
        {
            _context = context;
        }

        public async Task<TeamViewModel> AddTeam(CreateTeam team)
        {
            var alreadyExist = await _context.Teams.FirstOrDefaultAsync(t => t.Name == team.Name);

            if (alreadyExist != null)
                throw new Exception("Team already exists!");

            var newTeam = new Team
            {
                Name = team.Name
            };

            await _context.Teams.AddAsync(newTeam);
            await _context.SaveChangesAsync();

            if (team.PlayerIds != null && team.PlayerIds.Any())
            {
                var teamPlayers = team.PlayerIds.Select(playerId => new TeamPlayer
                {
                    TeamId = newTeam.Id,
                    PlayerId = playerId
                }).ToList();

                await _context.TeamPlayers.AddRangeAsync(teamPlayers);
                await _context.SaveChangesAsync();
            }

            return await GetTeamById(newTeam.Id);

        }

        public async Task<TeamViewModel> EditTeam(int id, string name)
        {
            var entity = await _context.Teams.FindAsync(id);

            if (entity != null)
            {
                entity.Name = name;

                await _context.SaveChangesAsync();
            }

            return await GetTeamById(id);
        }

        public async Task<TeamViewModel> GetTeamById(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            return ToTeamViewModel(team);
        }

        public async Task<PaginatedResponse<TeamViewModel>> GetTeams(GetTeamsRequestModel request)
        {
            var query = _context.Teams.AsQueryable();

            if (!string.IsNullOrEmpty(request.SearchText))
            {
                query = query.Where(x => x.Name.Contains(request.SearchText));
            }

            if (request.PlayerId.HasValue)
            {
                query = query.Where(t => t.TeamPlayers.Any(tp => tp.PlayerId == request.PlayerId));
            }

            query = query.OrderByColumn(request.SortByColumn, request.SortDirection == Enums.SortDirection.ASC);

            var result = await query.ToPaginatedAsync(request);

            return new PaginatedResponse<TeamViewModel>(ToTeamViewModel(result.Items.ToList()), result.TotalCount, result.PageNumber, result.PageSize);
        }

        private TeamViewModel ToTeamViewModel(Team team)
        {
            return new TeamViewModel
            {
                Id = team.Id,
                Name = team.Name
            };
        }

        private List<TeamViewModel> ToTeamViewModel(List<Team> teams)
        {
            return teams.Select(s => ToTeamViewModel(s)).ToList();
        }

        private TeamPlayerViewModel ToTeamPlayerViewModel(TeamPlayer teamPlayer)
        {
            return new TeamPlayerViewModel
            {
                Id = teamPlayer.Id,
                TeamId = teamPlayer.TeamId,
                PlayerId = teamPlayer.PlayerId
            };
        }

        private List<TeamPlayerViewModel> ToTeamPlayerViewModel(List<TeamPlayer> teamPlayers)
        {
            return teamPlayers.Select(s => ToTeamPlayerViewModel(s)).ToList();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Teams.AnyAsync(t => t.Id == id);
        }

        public async Task DeleteTeam(int id)
        {
            var teamToDelete = await _context.Teams.FindAsync(id);
            if (teamToDelete != null)
            {
                _context.Teams.Remove(teamToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TeamPlayerViewModel> GetTeamPlayerById(int id)
        {
            var teamPlayer = await _context.TeamPlayers.FindAsync(id);
            return ToTeamPlayerViewModel(teamPlayer);
        }

        public async Task<TeamPlayerViewModel> AddPlayerToTeam(int teamId, int playerId)
        {
            var isTeamExist = await _context.Teams.FindAsync(teamId);

            if (isTeamExist != null)
            {
                var newTeamPlayer = new TeamPlayer
                {
                    TeamId = teamId,
                    PlayerId = playerId
                };

                await _context.TeamPlayers.AddAsync(newTeamPlayer);
                await _context.SaveChangesAsync();
                return await GetTeamPlayerById(newTeamPlayer.Id);
            }

            else
            {
                throw new Exception("No such team exists!");
            }
        }

        public async Task RemovePlayerFromTeam(int teamId, int playerId)
        {
            var teamPlayerToBeDeleted = await _context.TeamPlayers.FirstOrDefaultAsync(x => x.TeamId == teamId && x.PlayerId == playerId);
            if (teamPlayerToBeDeleted != null)
            {
                _context.TeamPlayers.Remove(teamPlayerToBeDeleted);
                await _context.SaveChangesAsync();
            }
        }
    }
}