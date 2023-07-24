using Microsoft.EntityFrameworkCore;
using AsmtAPI.Data;

namespace AsmtAPI.Services.StudentService;

public class StudentService : IStudentService
{
    private readonly SchooldbContext _DBContext;

    public StudentService(SchooldbContext dBContext)
    {
        this._DBContext = dBContext;
    }

    async Task<List<Student>> IStudentService.GetAllStudents()
    {
        var studentList = _DBContext.Student.Include(student => student.Grade).ToListAsync();

        return (studentList == null) ? throw new Exception("student list is null") : await studentList;
    }
    async Task<Student> IStudentService.AddStudent(Student student)
    {
        try
        {
            _DBContext.Student.Add(student);
            _DBContext.SaveChanges();

            return student;
        }
        catch
        {
            throw new Exception("students not found");
        }
    }


    async Task<Student> IStudentService.GetStudentById(int id)
    {
        var student = await _DBContext.Student.FindAsync(id);

        return (student == null) ? throw new Exception("student not found") : student;
    }
    async Task<List<Student>> IStudentService.GetStudentByClassRange(int start, int end)
    {
        var students = _DBContext.Student
                                .Where(student => (int)student.Grade.GradeLevel >= start && (int)student.Grade.GradeLevel <= end)
                                .ToListAsync();
        return await students;
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