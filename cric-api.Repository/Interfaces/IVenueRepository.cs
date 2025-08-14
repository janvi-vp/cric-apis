using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.DTOs.Response;
using cric_api.DTOs.Utilities;

namespace cric_api.Repository.Interfaces
{
    public interface IVenueRepository
    {
        Task<PaginatedResponse<VenueViewModel>> GetAllVenues(GetVenuesRequestModel request);

        Task<VenueViewModel> GetVenueById(int id);

        Task<bool> IsExist(int id);

        Task <VenueViewModel> AddVenue(CreateVenue venue);

        Task <VenueViewModel> EditVenue(VenueViewModel venue);

        Task DeleteVenue(int id);
    }
}