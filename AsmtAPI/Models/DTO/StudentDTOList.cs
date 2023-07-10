namespace AsmtAPI.Models.DTO; //Data Transfer Objects 

public class StudentDTOList
{
    public int ID { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public Grade Grade { get; set; } = null!;
}



