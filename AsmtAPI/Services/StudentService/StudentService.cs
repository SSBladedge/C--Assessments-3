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
        _mapper = mapper;
    }

    async Task<ServicesResponse<List<GetStudentDTO>>> IStudentService.GetAllStudents()
    {
        try
        {
            var serviceResponse = new ServicesResponse<List<GetStudentDTO>>();
            var studentList = await _DBContext.Student
                                    .Include(student => student.Grade.GradeLevel)
                                    .Include(student => student.Grade.Teacher)
                                    .ToListAsync();
            serviceResponse.Data = studentList;
            return serviceResponse;
        }
        catch
        {
            throw new Exception("No records found");
        }
    }
    async Task<ServicesResponse<GetStudentDTO>> IStudentService.AddStudent(AddStudentDTO student)
    {
        try
        {
            var serviceResponse = new ServicesResponse<GetStudentDTO>();
            await _DBContext.Student.Add(student);
            serviceResponse.Data = student;
            _DBContext.SaveChanges();

            return serviceResponse;
        }
        catch
        {
            throw new Exception("students not found");
        }
    }


    async Task<ServicesResponse<GetStudentDTO>> IStudentService.GetStudentById(int id)
    {
        try
        {
            var serviceResponse = new ServicesResponse<GetStudentDTO>();
            var student = await _DBContext.Student.FindAsync(id);
            serviceResponse.Data = student;
            return serviceResponse;
        }
        catch
        {
            throw new Exception("student not found");
        }
    }
    async Task<ServicesResponse<List<GetStudentDTO>>> IStudentService.GetStudentByClassRange(int start, int end)
    {
        try
        {
            var serviceResponse = new ServicesResponse<List<GetStudentDTO>>();

            var students = await _DBContext.Student
                            .Where(student => (int)student.Grade.GradeLevel >= start
                                           && (int)student.Grade.GradeLevel <= end)
                            .ToListAsync();
            serviceResponse.Data = students;
            return serviceResponse;
        }
        catch
        {
            throw new Exception("No students were found");
        }
    }
}

// [HttpGet]                                                                   //GET ALL STUDENTS 
//     public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
//     {
//         var studentList = await _DBContext.Student.Include(student => student.Grade).ToListAsync();
//         return studentList;
//     }

//     [HttpPost]                                                                 //REGISTER A STUDENT 
//     public async Task<ActionResult<Student>> RegisterStudent(Student student)
//     {
//         _DBContext.Student.Add(student);
//         await _DBContext.SaveChangesAsync();

//         return Created("./api/Schooldb", new { id = student.ID });
//     }

//     [HttpGet("{id}")]                                                          //GET STUDENT WITH ID 
//     public async Task<ActionResult<Student>> GetStudent(int id)
//     {
//         var student = await _DBContext.Student.FindAsync(id);
//         return (student == null) ? NotFound() : student;
//     }

//     [HttpGet("{start}/{end}")]                                                  //GET STUDENT WITHIN GRADE RANGE 
//     public async Task<ActionResult<IEnumerable<Student>>> GetStudentByGrade(int start, int end)
//     {
//         var students = await _DBContext.Student
//                                        .Where(student => (int)student.Grade.GradeLevel >= start && (int)student.Grade.GradeLevel <= end)
//                                        .ToListAsync();
//         return students;
//     }

// return (studentList == null) ? throw new Exception("student list is null") : await studentList;