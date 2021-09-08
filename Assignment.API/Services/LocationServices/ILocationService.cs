using AutoWrapper.Wrappers;
using Context.Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LocationServices
{
    public interface ILocationService
    {
        Task<ApiResponse> SaveAsync(CreateUpdateLocationDto locationDto);
        Task<ApiResponse> UpdateAsync(CreateUpdateLocationDto locationDto);
        Task<PageResponseModel<Location>> GetAll(PageRequestModel pagedRequest);
        Task<Location> Details(int Id);
        Task<Location> Delete(int Id);
    }
}
