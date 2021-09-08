using AutoWrapper.Wrappers;
using Context.Models;
using Microsoft.AspNetCore.Mvc;
using Services.BranchServices;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Assignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        [HttpPost("Add")]
        public async Task<ApiResponse> Add([FromBody] CreateUpdateBranchDto createUpdateBranchDto)
        {
            try
            {
                var result = await _branchService.SaveAsync(createUpdateBranchDto);
                return new ApiResponse { Result = result, StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Result = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, IsError = true };
            }
        }

        [HttpPost("Update")]
        public async Task<ApiResponse> Update([FromBody] CreateUpdateBranchDto createUpdateBranchDto)
        {
            try
            {
                var result = await _branchService.UpdateAsync(createUpdateBranchDto);
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
                var result = await _branchService.GetAll(requestModel);
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
                var result = await _branchService.Details(Id);
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
                var result = await _branchService.Delete(Id);
                return new ApiResponse { Result = result, StatusCode = (int)HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Result = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, IsError = true };
            }
        }
    }
}
