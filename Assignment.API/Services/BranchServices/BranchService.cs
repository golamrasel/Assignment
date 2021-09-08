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

namespace Services.BranchServices
{
    public class BranchService : IBranchService
    {
        private readonly AssigmentContext _context;
        public BranchService(AssigmentContext context)
        {
            _context = context;
        }
        public async Task<Branch> Details(int Id)
        {
            var result = await _context.Branches.FindAsync(Id);
            if (result == null)
                throw new SystemException("This branch is not found!!");
            return result;
        }

        public async Task<PageResponseModel<Branch>> GetAll(PageRequestModel pagedRequest)
        {
            int pageSize = pagedRequest.PageSize == 0 ? 10 : pagedRequest.PageSize;
            int pageNo = pagedRequest.PageNo - 1;

            var query = _context.Branches.Where(x => x.BranchName.ToLower().Contains(pagedRequest.Keyword.ToLower()));
            var totalCount = await query.CountAsync();

            var result = await query.Skip(pageNo * pageSize).Take(pageSize).ToListAsync();
            var response = new PageResponseModel<Branch>()
            {
                Rows = result,
                Count = totalCount

            };
            return response;
        }

        public async Task<ApiResponse> SaveAsync(CreateUpdateBranchDto branchDto)
        {
            var branch = new Branch()
            {
                BranchName = branchDto.BranchName,
                Password = branchDto.Password,
                Mac = branchDto.Mac,
            };
            await _context.Branches.AddAsync(branch);
            await _context.SaveChangesAsync();
            return new ApiResponse { Result = "Saved Successfully!!" };
        }

        public async Task<ApiResponse> UpdateAsync(CreateUpdateBranchDto branchDto)
        {
            var entity = await _context.Branches.FindAsync(branchDto.Id);
            entity.Id = branchDto.Id;
            entity.BranchName = branchDto.BranchName;
            entity.Password = branchDto.Password;
            entity.Mac = branchDto.Mac;

            await _context.SaveChangesAsync();
            return new ApiResponse { Result = "Update Successfully!!" };
        }

        public async Task<Branch> Delete(int Id)
        {
            var entity = await _context.Branches.FindAsync(Id);
            if (entity == null)
                throw new SystemException("This branch is not found!!");
            _context.Branches.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
