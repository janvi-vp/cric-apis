using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.DTOs.Response;
using cric_api.DTOs.Utilities;
using cric_api.Repository.Interfaces;
using cric_api.Services.Interfaces;

namespace cric_api.Services.Services
{
    public class VenueService : IVenueService
    {
        private IVenueRepository _repository;

        public VenueService(IVenueRepository repository)
        {
            _repository = repository;
        }

        public async Task<VenueViewModel> AddVenue(CreateVenue venue)
        {
            var newVenue = await _repository.AddVenue(venue);
            return newVenue;
        }

        public async Task DeleteVenue(int id)
        {
            await _repository.DeleteVenue(id);
        }

        public async Task<VenueViewModel> EditVenue(EditVenue editVenue, int id)
        {
            var isExist = await _repository.IsExist(id);

            if (!isExist)
            {
                throw new Exception("No such venue exists!");
            }

            var entity = await _repository.GetVenueById(id);

            if (!string.IsNullOrEmpty(editVenue.Name) && editVenue.Name != entity.Name)
            {
                entity.Name = editVenue.Name;
            }

            if (!string.IsNullOrEmpty(editVenue.City) && editVenue.City != entity.City)
            {
                entity.City = editVenue.City;
            }

            if (!string.IsNullOrEmpty(editVenue.State) && editVenue.State != entity.State)
            {
                entity.State = editVenue.State;
            }

            if (!string.IsNullOrEmpty(editVenue.Country) && editVenue.Country != entity.Country)
            {
                entity.Country = editVenue.Country;
            }

            var editedVenue = await _repository.EditVenue(entity);

            return editedVenue;
        }

        public async Task<PaginatedResponse<VenueViewModel>> GetAllVenues(GetVenuesRequestModel request)
        {
            return await _repository.GetAllVenues(request);
        }
    }
}