using AutoWrapper.Wrappers;
using Context.Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BranchServices
{
    public interface IBranchService
    {
        Task<ApiResponse> SaveAsync(CreateUpdateBranchDto branchDto);
        Task<ApiResponse> UpdateAsync(CreateUpdateBranchDto branchDto);
        Task<PageResponseModel<Branch>> GetAll(PageRequestModel pagedRequest);
        Task<Branch> Details(int Id);
        Task<Branch> Delete(int Id);
    }
}
