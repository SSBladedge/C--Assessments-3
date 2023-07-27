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
        var response = await _studentService.GetAllStudents();
        return response.Data is null ? NotFound(response) : Ok(response);
    }

    [HttpPost]                                                                 //REGISTER A STUDENT 
    public async Task<ActionResult<ServicesResponse<GetStudentResponseDTO>>> RegisterStudent(AddStudentRequestDTO newStudent)
    {
        var response = await _studentService.AddStudent(newStudent);
        return response.Data is null ? NotFound(response) : Ok(response);
    }

    [HttpGet("{id}")]                                                          //GET STUDENT WITH ID 
    public async Task<ActionResult<ServicesResponse<GetStudentResponseDTO>>> GetStudent(int id)
    {
        var response = await _studentService.GetStudentById(id);
        return response.Data is null ? NotFound(response) : Ok(response);

    }

    [HttpGet("{start}/{end}")]                                                  //GET STUDENT WITHIN GRADE RANGE 
    public async Task<ActionResult<ServicesResponse<List<GetStudentResponseDTO>>>> GetStudentByGrade(int start, int end)
    {
        var response = await _studentService.GetStudentByClassRange(start, end);
        return response.Data is null ? NotFound(response) : Ok(response);
    }

    [HttpPut]                                                                   //UPPDATE STUDENT
    public async Task<ActionResult<ServicesResponse<GetStudentResponseDTO>>> UpdateStudent(UpdateStudentRequestDTO updatedStudent)
    {
        var response = await _studentService.UpdateStudent(updatedStudent);
        return response.Data is null ? NotFound(response) : Ok(response);
    }

    [HttpDelete]                                                               //DELETE STUDENT
    public async Task<ActionResult<ServicesResponse<GetStudentResponseDTO>>> DeleteStudent(int id)
    {
        var response = await _studentService.DeleteStudentById(id);
        return response.Data is null ? NotFound(response) : Ok(response);
    }


}






