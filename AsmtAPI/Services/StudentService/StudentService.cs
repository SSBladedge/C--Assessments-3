using Microsoft.EntityFrameworkCore;
using AsmtAPI.Data;
using AutoMapper;

namespace AsmtAPI.Services.StudentService;

public class StudentService : IStudentService
{
    private readonly SchooldbContext _DBContext;
    private readonly IMapper _mapper;

    public StudentService(SchooldbContext dBContext, IMapper mapper)
    {
        this._DBContext = dBContext;
        this._mapper = mapper;
    }

    async Task<ServicesResponse<List<GetStudentResponseDTO>>> IStudentService.GetAllStudents()
    {
        try
        {
            var serviceResponse = new ServicesResponse<List<GetStudentResponseDTO>>();
            var students = await _DBContext.Student
                                    .Include(student => student.Grade.GradeLevel)
                                    .Include(student => student.Grade.Teacher)
                                    .ToListAsync();
            serviceResponse.Data = students.Select(student => _mapper.Map<GetStudentResponseDTO>(student)).ToList();
            return serviceResponse;
        }
        catch
        {
            throw new Exception("No records found");
        }
    }
    async Task<ServicesResponse<GetStudentResponseDTO>> IStudentService.AddStudent(AddStudentRequestDTO student)
    {
        try
        {
            var serviceResponse = new ServicesResponse<GetStudentResponseDTO>();
            _DBContext.Student.Add(_mapper.Map<Student>(student));
            serviceResponse.Data = _mapper.Map<GetStudentResponseDTO>(student); ;
            _DBContext.SaveChanges();

            return serviceResponse;
        }
        catch
        {
            throw new Exception("students not found");
        }
    }


    async Task<ServicesResponse<GetStudentResponseDTO>> IStudentService.GetStudentById(int id)
    {
        try
        {
            var serviceResponse = new ServicesResponse<GetStudentResponseDTO>();
            var student = await _DBContext.Student.FindAsync(id);
            serviceResponse.Data = _mapper.Map<GetStudentResponseDTO>(student);
            return serviceResponse;
        }
        catch
        {
            throw new Exception("student not found");
        }
    }
    async Task<ServicesResponse<List<GetStudentResponseDTO>>> IStudentService.GetStudentByClassRange(int start, int end)
    {
        try
        {
            var serviceResponse = new ServicesResponse<List<GetStudentResponseDTO>>();
            var students = await _DBContext.Student
                            .Where(student => (int)student.Grade.GradeLevel >= start
                                           && (int)student.Grade.GradeLevel <= end)
                            .ToListAsync();
            serviceResponse.Data = students.Select(student => _mapper.Map<GetStudentResponseDTO>(student)).ToList();
            return serviceResponse;
        }
        catch
        {
            throw new Exception("No students were found");
        }
    }
}