using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cric_api.DTOs.DTOs.Request;
using cric_api.DTOs.Utilities;
using cric_api.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace cric_apis.Controllers
{
    [Route("cric_apis/venues")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IVenueService _service;

        public VenueController(IVenueService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAllVenues([FromQuery] GetVenuesRequestModel request)
        {
            var venues = await _service.GetAllVenues(request);
            return Ok(ApiResponse<object>.Ok(venues));
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddVenue([FromBody] CreateVenue venue)
        {
            var newVenue = await _service.AddVenue(venue);
            return Ok(ApiResponse<object>.Ok(newVenue));
        }
        
        [HttpPut]
        [Route("edit/{id}")]
        public async Task<IActionResult> EditVenue([FromRoute] int id, [FromBody] EditVenue editVenue)
        {
            var editedVenue = await _service.EditVenue(editVenue, id);
            return Ok(ApiResponse<object>.Ok(editedVenue));
        }

        [HttpDelete]
        [Route("delete/{id}")]

        public async Task<IActionResult> DeleteVenue([FromRoute] int id)
        {
            await _service.DeleteVenue(id);
            return Ok(ApiResponse<object>.Ok(true));
        }
    }
}