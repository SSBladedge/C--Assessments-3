namespace AsmtAPI.DTOs.StudentDTOs;

public class UpdateStudentRequestDTO
{
    public int ID { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;

}