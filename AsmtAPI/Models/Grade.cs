namespace AsmtAPI.Models;

public enum GradeLevel
{
    Year_1 = 1,
    Year_2 = 2,
    Year_3 = 3,
    Year_4 = 4,
    Year_5 = 5,
    Year_6 = 6
}

public class Grade
{
    public int GradeID { get; set; }

    public GradeLevel GradeLevel { get; set; }

    public string Teacher { get; set; } = null!;

    public ICollection<Student> Students { get; } = new List<Student>();
}
