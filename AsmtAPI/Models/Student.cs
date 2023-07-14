using System.ComponentModel.DataAnnotations.Schema;
namespace AsmtAPI.Models;

public class Student
{
    public int ID { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }  //DateOnly??

    public string? Address { get; set; } = null!;

    public virtual Grade Grade { get; set; } = null!;

}
