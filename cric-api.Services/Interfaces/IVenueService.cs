using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.DTOs.Response;
using cric_api.DTOs.Utilities;

namespace cric_api.Services.Interfaces
{
    public interface IVenueService
    {
        Task<PaginatedResponse<VenueViewModel>> GetAllVenues(GetVenuesRequestModel request);

        Task <VenueViewModel> AddVenue(CreateVenue venue);

        Task <VenueViewModel> EditVenue(EditVenue editVenue, int id);

        Task DeleteVenue(int id);
    }
}