namespace AsmtAPI.Services.StudentService;

public interface IStudentService
{
    Task<ServicesResponse<List<GetStudentResponseDTO>>> GetAllStudents();
    Task<ServicesResponse<GetStudentResponseDTO>> AddStudent(AddStudentRequestDTO student);
    Task<ServicesResponse<GetStudentResponseDTO>> GetStudentById(int id);
    Task<ServicesResponse<List<GetStudentResponseDTO>>> GetStudentByClassRange(int start, int end);

}


