namespace AsmtAPI.Services.StudentService;

public interface IStudentService
{
    Task<ServicesResponse<List<GetStudentResponseDTO>>> GetAllStudents();
    Task<ServicesResponse<GetStudentResponseDTO>> AddStudent(AddStudentRequestDTO newStudent);
    Task<ServicesResponse<GetStudentResponseDTO>> GetStudentById(int id);
    Task<ServicesResponse<List<GetStudentResponseDTO>>> GetStudentByClassRange(int start, int end);
    Task<ServicesResponse<GetStudentResponseDTO>> UpdateStudent(UpdateStudentRequestDTO updatedStudent);
    Task<ServicesResponse<List<GetStudentResponseDTO>>> DeleteStudentById(int id);
}


