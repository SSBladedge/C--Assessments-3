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

    //Class Records go here 


    [HttpGet]                                                                   //GET ALL STUDENTS 
    public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
    {
        return await _DBContext.Student.ToListAsync();
    }

    [HttpPost]                                                                 //REGISTER A STUDENT 
    public async Task<ActionResult<Student>> RegisterStudent(Student student)
    {
        _DBContext.Student.Add(student);
        await _DBContext.SaveChangesAsync();

        return CreatedAtAction("Get student", new { id = student.ID }, student);
    }

    [HttpGet("{id}")]                                                          //GET STUDENT WITH ID 
    public async Task<ActionResult<Student>> GetStudentById(int id)
    {
        var student = await _DBContext.Student.FindAsync(id);
        return (student == null) ? NotFound() : student;
    }

    [HttpGet("{start}/{end}")]                                                  //GET STUDENT WITHIN GRADE RANGE 
    public async Task<ActionResult<IEnumerable<Student>>> GetStudentByGrade(int start, int end)
    {
        var students = (from student in _DBContext.Student
                        where start <= (int)student.Grade.GradeLevel &&
                        (int)student.Grade.GradeLevel <= end
                        select student);

        return await students.ToListAsync();
    }


}







