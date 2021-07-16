using AutoWrapper.Wrappers;
using Context.Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.StudentServices
{
    public interface IStudentService
    {
        Task<ApiResponse> SaveAsync(CreateUpdateStudentDto studentDto);
        Task<ApiResponse> UpdateAsync(CreateUpdateStudentDto studentDto);
        Task<PageResponseModel<Student>> GetAll(PageRequestModel pagedRequest);
        Task<Student> Details(int Id);
        Task<Student> Delete(int Id);


    }
}
