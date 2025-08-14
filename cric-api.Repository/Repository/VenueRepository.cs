using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.Data;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.DTOs.Response;
using cric_api.DTOs.Utilities;
using cric_api.Models.Models;
using cric_api.Repository.Interfaces;
using cric_api.Repository.Utilities;
using Microsoft.EntityFrameworkCore;

namespace cric_api.Repository.Repository
{
    public class VenueRepository : IVenueRepository
    {
        private readonly CricContext _context;

        public VenueRepository(CricContext context)
        {
            _context = context;
        }

        public async Task<VenueViewModel> AddVenue(CreateVenue venue)
        {
            var alreadyExist = await _context.Venues.Where(p => p.Name == venue.Name).FirstOrDefaultAsync();

            if (alreadyExist == null)
            {
                var newVenue = new Venue()
                {
                    Name = venue.Name,
                    City = venue.City,
                    State = venue.State,
                    Country = venue.Country
                };

                await _context.Venues.AddAsync(newVenue);
                await _context.SaveChangesAsync();
                return await GetVenueById(newVenue.Id);
            }

            else
            {
                throw new Exception("Venue Already Exists");
            }
        }

        public async Task DeleteVenue(int id)
        {
            var venueToDelete = await _context.Venues.FindAsync(id);
            if (venueToDelete != null)
            {
                _context.Venues.Remove(venueToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<VenueViewModel> EditVenue(VenueViewModel venue)
        {
            var entity = await _context.Venues.FindAsync(venue.Id);
            if (entity != null)
            {
                entity.Name = venue.Name;
                entity.City = venue.City;
                entity.State = venue.State;
                entity.Country = venue.Country;

                await _context.SaveChangesAsync();
            }
            return await GetVenueById(venue.Id);
        }

        public async Task<PaginatedResponse<VenueViewModel>> GetAllVenues(GetVenuesRequestModel request)
        {
            IQueryable<Venue> query = _context.Venues;

            if (!string.IsNullOrEmpty(request.SearchText))
            {
                query = query.Where(x => x.Name.Contains(request.SearchText) || x.City.Contains(request.SearchText) || x.State.Contains(request.SearchText) || x.Country.Contains(request.SearchText));
            }

            query = query.OrderByColumn(request.SortByColumn, request.SortDirection == Enums.SortDirection.ASC);

            var result = await query.ToPaginatedAsync(request);

            return new PaginatedResponse<VenueViewModel>(result.Items.ToList().ToViewModel(), result.TotalCount, result.PageNumber, result.PageSize);
        }

        public async Task<VenueViewModel> GetVenueById(int id)
        {
            var venue = await _context.Venues.FindAsync(id);
            return venue.ToViewModel();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.Venues.AnyAsync(p => p.Id == id);
        }
    }
}