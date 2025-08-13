using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Data;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.DTOs.Response;
using cric_api.DTOs.Utilities;
using cric_api.Models;
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

            if (alreadyExist == null)
            {
                var newTeam = new Team
                {
                    Name = team.Name
                };

                await _context.Teams.AddAsync(newTeam);
                await _context.SaveChangesAsync();
                return await GetTeamById(newTeam.Id);
            }
            else
            {
                throw new Exception("Team already exists!");
            }
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
    }
}