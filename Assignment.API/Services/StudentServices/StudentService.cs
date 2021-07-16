using AutoWrapper.Wrappers;
using Context;
using Context.Models;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly AssigmentContext _context;
        public StudentService(AssigmentContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse> SaveAsync(CreateUpdateStudentDto studentDto)
        {
            var student = new Student()
            {
                StudentName = studentDto.StudentName,
                Class = studentDto.Class,
                Roll = studentDto.Roll,
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return new ApiResponse { Result = "Saved Successfully!!" };
        }

        public async Task<ApiResponse> UpdateAsync(CreateUpdateStudentDto studentDto)
        {
            var entity = await _context.Students.FindAsync(studentDto.studentId);
            entity.StudentId = studentDto.studentId;
            entity.StudentName = studentDto.StudentName;
            entity.Roll = studentDto.Roll;
            entity.Class = studentDto.Class;

            await _context.SaveChangesAsync();
            return new ApiResponse { Result = "Update Successfully!!" };
        }

        public async Task<Student> Delete(int Id)
        {
            var entity = await _context.Students.FindAsync(Id);
            if (entity == null)
                throw new SystemException("This student is not found!!");
            _context.Students.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Student> Details(int Id)
        { 
            var result = await _context.Students.FindAsync(Id);
            if (result == null)
                throw new SystemException("This student is not found!!");
            return result;
        }
        public async Task<PageResponseModel<Student>> GetAll(PageRequestModel pagedRequest)
        {
            int pageSize = pagedRequest.PageSize == 0 ? 10 : pagedRequest.PageSize;
            int pageNo = pagedRequest.PageNo - 1;

            var query =  _context.Students.Where(x => x.StudentName.ToLower().Contains(pagedRequest.Keyword.ToLower()));
            var totalCount = await query.CountAsync();

            var result =  await query.Skip(pageNo * pageSize).Take(pageSize).ToListAsync();
            var response = new PageResponseModel<Student>()
            {
                Rows = result,
                Count = totalCount

            };
            return response;
        }
    }
}
