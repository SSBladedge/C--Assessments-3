namespace AsmtAPI.DTOs;

public class AddStudentRequestDTO
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public Grade Grade { get; set; } = null!;
}



