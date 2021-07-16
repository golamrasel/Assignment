using AutoWrapper.Wrappers;
using Context.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;
using Services.StudentServices;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Assignment.API.Controllers
{
    namespace Notification.API.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class StudentController : ControllerBase
        {
            private IStudentService _studentService;

            public StudentController(IStudentService studentService)
            {
                _studentService = studentService;
            }

            [HttpPost("Add")]
            public async Task<ApiResponse> Add([FromBody] CreateUpdateStudentDto createUpdateStudentDto)
            {
                try
                {
                    var result = await _studentService.SaveAsync(createUpdateStudentDto);
                    return new ApiResponse { Result = result, StatusCode = (int)HttpStatusCode.OK };
                }
                catch (Exception ex)
                {
                    return new ApiResponse { Result = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, IsError = true };
                }
            }

            [HttpPost("Update")]
            public async Task<ApiResponse> Update([FromBody] CreateUpdateStudentDto createUpdateStudentDto)
            {
                try
                {
                    var result = await _studentService.UpdateAsync(createUpdateStudentDto);
                    return new ApiResponse { Result = result, StatusCode = (int)HttpStatusCode.OK };
                }
                catch (Exception ex)
                {
                    return new ApiResponse { Result = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, IsError = true };
                }
            }

            [HttpPost("All")]
            public async Task<ApiResponse> All([FromBody] PageRequestModel requestModel)
            {
                try
                {
                    var result = await _studentService.GetAll(requestModel);
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
                    var result = await _studentService.Details(Id);
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
                    var result = await _studentService.Delete(Id);
                    return new ApiResponse { Result = result, StatusCode = (int)HttpStatusCode.OK };
                }
                catch (Exception ex)
                {
                    return new ApiResponse { Result = ex.Message, StatusCode = (int)HttpStatusCode.BadRequest, IsError = true };
                }
            }
        }

    }
}

