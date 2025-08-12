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

namespace cric_api.Repository.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly CricContext _context;

        public TeamRepository(CricContext context)
        {
            _context = context;
        }
        public async Task<PaginatedResponse<TeamViewModel>> GetTeams(GetTeamsRequestModel request)
        {
            IQueryable<Team> query = _context.Teams;

            if (!string.IsNullOrEmpty(request.SearchText))
            {
                query = query.Where(x => x.Name.Contains(request.SearchText));
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
    }
}