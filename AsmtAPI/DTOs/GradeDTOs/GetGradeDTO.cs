namespace AsmtAPI.DTOs.GradeDTOs;

public class GetGradeResponseDTO
{
    public int GradeID { get; set; }

    public GradeLevel GradeLevel { get; set; }

    public string Teacher { get; set; } = null!;

    public List<Student>? Students { get; set; }
}



