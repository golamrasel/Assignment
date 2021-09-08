using AutoWrapper.Wrappers;
using Context;
using Context.Models;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.LocationServices
{
    public class LocationService : ILocationService
    {
        private readonly AssigmentContext _context;
        public LocationService(AssigmentContext context)
        {
            _context = context;
        }
        public async Task<Location> Delete(int Id)
        {
            var entity = await _context.Locations.FindAsync(Id);
            if (entity == null)
                throw new SystemException("This location is not found!!");
            _context.Locations.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Location> Details(int Id)
        {
            var result = await _context.Locations.FindAsync(Id);
            if (result == null)
                throw new SystemException("This location is not found!!");
            return result;
        }

        public async Task<PageResponseModel<Location>> GetAll(PageRequestModel pagedRequest)
        {
            int pageSize = pagedRequest.PageSize == 0 ? 10 : pagedRequest.PageSize;
            int pageNo = pagedRequest.PageNo - 1;

            var query = _context.Locations.Where(x => x.LocationName.ToLower().Contains(pagedRequest.Keyword.ToLower()));
            var totalCount = await query.CountAsync();

            var result = await query.Skip(pageNo * pageSize).Take(pageSize).ToListAsync();
            var response = new PageResponseModel<Location>()
            {
                Rows = result,
                Count = totalCount

            };
            return response;
        }

        public async Task<ApiResponse> SaveAsync(CreateUpdateLocationDto locationDto)
        {
            var location = new Location()
            {
                LocationName = locationDto.LocationName,
                Rate = locationDto.Rate,
                BranchId = locationDto.BranchId,
            };
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
            return new ApiResponse { Result = "Saved Successfully!!" };
        }

        public async Task<ApiResponse> UpdateAsync(CreateUpdateLocationDto locationDto)
        {
            var entity = await _context.Locations.FindAsync(locationDto.Id);
            entity.Id = locationDto.Id;
            entity.LocationName = locationDto.LocationName;
            entity.Rate = locationDto.Rate;
            entity.BranchId = locationDto.BranchId;

            await _context.SaveChangesAsync();
            return new ApiResponse { Result = "Update Successfully!!" };
        }
    }
}
