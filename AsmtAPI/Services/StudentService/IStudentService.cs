using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AsmtAPI.Data;

namespace AsmtAPI.Services.StudentService;

public interface IStudentService
{
    Task<ServicesResponse<List<GetStudentDTO>>> GetAllStudents();
    Task<ServicesResponse<GetStudentDTO>> AddStudent(AddStudentDTO student);
    Task<ServicesResponse<GetStudentDTO>> GetStudentById(int id);
    Task<ServicesResponse<List<GetStudentDTO>>> GetStudentByClassRange(int start, int end);

}


