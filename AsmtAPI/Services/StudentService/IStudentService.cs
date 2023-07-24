using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AsmtAPI.Data;

namespace AsmtAPI.Services.StudentService;

public interface IStudentService
{
    Task<List<Student>> GetAllStudents();
    Task<Student> AddStudent(Student student);
    Task<Student> GetStudentById(int id);
    Task<List<Student>> GetStudentByClassRange(int start, int end);

}


