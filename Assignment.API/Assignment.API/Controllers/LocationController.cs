using AutoWrapper.Wrappers;
using Context.Models;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpPost("Add")]
        public async Task<ApiResponse> Add([FromBody] CreateUpdateLocationDto createUpdateLocationDto)
        {
            try
            {
                var result = await _locationService.SaveAsync(createUpdateLocationDto);
                return new ApiResponse { Result = result, StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Result = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, IsError = true };
            }
        }

        [HttpPost("Update")]
        public async Task<ApiResponse> Update([FromBody] CreateUpdateLocationDto createUpdateLocationDto)
        {
            try
            {
                var result = await _locationService.UpdateAsync(createUpdateLocationDto);
                return new ApiResponse { Result = result, StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Result = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, IsError = true };
            }
        }

        [HttpPost("All")]
        public async Task<ApiResponse> All(PageRequestModel requestModel)
        {
            try
            {
                var result = await _locationService.GetAll(requestModel);
                return new ApiResponse { Result = result, StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Result = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, IsError = true };
            }
        }

        [HttpGet("Details")]
        public async Task<ApiResponse> Details(int Id)
        {
            try
            {
                var result = await _locationService.Details(Id);
                return new ApiResponse { Result = result, StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Result = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, IsError = true };
            }
        }

        [HttpDelete("Delete")]
        public async Task<ApiResponse> Delete(int Id)
        {
            try
            {
                var result = await _locationService.Delete(Id);
                return new ApiResponse { Result = result, StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Result = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, IsError = true };
            }
        }
    }
}
