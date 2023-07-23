namespace AsmtAPI.Models;

public class Grade
{
    public int GradeID { get; set; }

    public GradeLevel GradeLevel { get; set; }

    public string Teacher { get; set; } = null!;

    public ICollection<Student> Students { get; } = new List<Student>();
}


