using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<ServicesResponse<List<GetStudentResponseDTO>>>> GetAllStudents()
    {
        return Ok(await _studentService.GetAllStudents());
    }

    [HttpPost]                                                                 //REGISTER A STUDENT 
    public async Task<ActionResult<ServicesResponse<GetStudentResponseDTO>>> RegisterStudent(AddStudentRequestDTO student)
    {
        return Ok(await _studentService.AddStudent(student));
    }

    [HttpGet("{id}")]                                                          //GET STUDENT WITH ID 
    public async Task<ActionResult<ServicesResponse<GetStudentResponseDTO>>> GetStudent(int id)
    {
        return Ok(await _studentService.GetStudentById(id));
    }

    [HttpGet("{start}/{end}")]                                                  //GET STUDENT WITHIN GRADE RANGE 
    public async Task<ActionResult<ServicesResponse<List<GetStudentResponseDTO>>>> GetStudentByGrade(int start, int end)
    {
        return Ok(await _studentService.GetStudentByClassRange(start, end));
    }
}






