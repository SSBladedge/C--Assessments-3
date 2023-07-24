using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AsmtAPI.Data;



namespace AsmtAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchooldbController : ControllerBase
{

    private readonly IStudentService _studentService;

    public SchooldbController(IStudentService studentService)
    {
        this._studentService = studentService;
    }


    [HttpGet]                                                                   //GET ALL STUDENTS 
    public async Task<ActionResult<List<Student>>> GetAllStudents()
    {
        return Ok(await _studentService.GetAllStudents());
    }

    [HttpPost]                                                                 //REGISTER A STUDENT 
    public async Task<ActionResult<Student>> RegisterStudent(Student student)
    {
        await _studentService.AddStudent(student);
        return Created("./api/Schooldb", new { id = student.ID });
    }

    [HttpGet("{id}")]                                                          //GET STUDENT WITH ID 
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        return Ok(await _studentService.GetStudentById(id));
    }

    [HttpGet("{start}/{end}")]                                                  //GET STUDENT WITHIN GRADE RANGE 
    public async Task<ActionResult<List<Student>>> GetStudentByGrade(int start, int end)
    {
        return Ok(await _studentService.GetStudentByClassRange(start, end));
    }
}

//REMOVE ALL _DBContext REFERENCES - create school service to map DTOs and receive requests to _DBContext (it will be in service folder)

//ADD A TRY/CATCH TO ALL REQUESTS IN CONTROLLER





