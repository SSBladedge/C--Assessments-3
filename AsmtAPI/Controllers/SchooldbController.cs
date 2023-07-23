using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AsmtAPI.Models;
using AsmtAPI.Data;



namespace AsmtAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchooldbController : ControllerBase
{

    private readonly SchooldbContext _DBContext;

    public SchooldbController(SchooldbContext dBContext)
    {
        this._DBContext = dBContext;
    }


    [HttpGet]                                                                   //GET ALL STUDENTS 
    public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
    {
        var studentList = await _DBContext.Student.Include(student => student.Grade).ToListAsync();
        return studentList;
    }

    [HttpPost]                                                                 //REGISTER A STUDENT 
    public async Task<ActionResult<Student>> RegisterStudent(Student student)
    {
        _DBContext.Student.Add(student);
        await _DBContext.SaveChangesAsync();

        return Created("./api/Schooldb", new { id = student.ID });
    }

    [HttpGet("{id}")]                                                          //GET STUDENT WITH ID 
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        var student = await _DBContext.Student.FindAsync(id);
        return (student == null) ? NotFound() : student;
    }

    [HttpGet("{start}/{end}")]                                                  //GET STUDENT WITHIN GRADE RANGE 
    public async Task<ActionResult<IEnumerable<Student>>> GetStudentByGrade(int start, int end)
    {
        var students = await _DBContext.Student
                                       .Where(student => (int)student.Grade.GradeLevel >= start && (int)student.Grade.GradeLevel <= end)
                                       .ToListAsync();
        return students;
    }
}

//REMOVE ALL _DBContext REFERENCES - create school service to map DTOs and receive requests to _DBContext (it will be in service folder)

//ADD A TRY/CATCH TO ALL REQUESTS IN CONTROLLER





