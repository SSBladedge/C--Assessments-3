namespace AsmtAPI.DTOs.StudentDTOs;

public class GetStudentResponseDTO
{
    public int ID { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public GradeLevel GradeLevel { get; set; }

    public string Teacher { get; set; } = null!;
}



