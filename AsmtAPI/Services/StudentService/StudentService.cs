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

    async Task<ServicesResponse<List<GetStudentResponseDTO>>> IStudentService.GetAllStudents()                        //GET ALL STUDENTS
    {
        var serviceResponse = new ServicesResponse<List<GetStudentResponseDTO>>();
        try
        {
            var students = await _DBContext.Student.ToListAsync();
            serviceResponse.Data = students.Select(student => _mapper.Map<GetStudentResponseDTO>(student)).ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
    async Task<ServicesResponse<GetStudentResponseDTO>> IStudentService.AddStudent(AddStudentRequestDTO newStudent)    //ADD STUDENT
    {
        var serviceResponse = new ServicesResponse<GetStudentResponseDTO>();
        try
        {
            var student = _mapper.Map<Student>(newStudent);
            _DBContext.Student.Add(student);
            serviceResponse.Data = _mapper.Map<GetStudentResponseDTO>(student);
            await _DBContext.SaveChangesAsync();

        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }


    async Task<ServicesResponse<GetStudentResponseDTO>> IStudentService.GetStudentById(int id)                         //GET STUDENTS BY ID
    {
        var serviceResponse = new ServicesResponse<GetStudentResponseDTO>();
        try
        {
            var student = await _DBContext.Student.FindAsync(id);
            serviceResponse.Data = _mapper.Map<GetStudentResponseDTO>(student);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
    async Task<ServicesResponse<List<GetStudentResponseDTO>>> IStudentService.GetStudentByClassRange(int start, int end)  //GET STUDENTS BY CLASSES
    {
        var serviceResponse = new ServicesResponse<List<GetStudentResponseDTO>>();
        try
        {
            var students = await _DBContext.Student
                            .Where(student => (int)student.Grade.GradeLevel >= start
                                           && (int)student.Grade.GradeLevel <= end)
                            .ToListAsync();
            serviceResponse.Data = students.Select(student => _mapper.Map<GetStudentResponseDTO>(student)).ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    async Task<ServicesResponse<GetStudentResponseDTO>> IStudentService.UpdateStudent(UpdateStudentRequestDTO updatedStudent) //UPDATE STUDENT
    {
        var serviceResponse = new ServicesResponse<GetStudentResponseDTO>();
        try
        {
            var student = await _DBContext.Student.FindAsync(updatedStudent.ID);

            if (student is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Student with id {updatedStudent.ID} does not exist in records";
            }
            else
            {
                _mapper.Map(updatedStudent, student);
                _DBContext.SaveChanges();

                serviceResponse.Data = _mapper.Map<GetStudentResponseDTO>(student);
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }

    async Task<ServicesResponse<List<GetStudentResponseDTO>>> IStudentService.DeleteStudentById(int id)                       //DELETE STUDENT
    {
        var serviceResponse = new ServicesResponse<List<GetStudentResponseDTO>>();
        try
        {
            var student = await _DBContext.Student.FindAsync(id);

            if (student is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Student with id {id} does not exist in records";
            }
            else
            {
                _DBContext.Student.Remove(student);
                _DBContext.SaveChanges();

                serviceResponse.Data = _DBContext.Student
                                            .Select(student => _mapper
                                            .Map<GetStudentResponseDTO>(student))
                                            .ToList();
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
}