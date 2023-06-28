using Microsoft.AspNetCore.Mvc;
using AsmtAPI.Data;
using AsmtAPI.Models;


namespace AsmtAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchooldbController : ControllerBase
{
    private readonly SchooldbContext _DBContext;

    public SchooldbController(SchooldbContext dBContext)
    {
        this._DBContext = dBContext;
    }


    [HttpGet(Name = "Get all Student records")]
    public IEnumerable<Student> GetAllStudents()
    {
        var records = from students in _DBContext.Student
                      select students;

        return records.ToArray();
    }

    [HttpGet(Name = "Get student records by grade")]
    public IEnumerable<Student> GetStudentsByGrade(int gradeStart, int gradeEnd)
    {
        var records = from students in _DBContext.Student
                      where gradeStart <= (int)students.Grade.GradeLevel &&
                      (int)students.Grade.GradeLevel <= gradeEnd
                      select students;

        return records.ToArray();
    }

    [HttpGet(Name = "Get student record using id")]
    public IActionResult GetStudentById(int id)
    {
        var student = from students in _DBContext.Student
                      where students.ID == id
                      select students;

        return Ok(student);
    }

    // [HttpPost(Name = "Add a student")]
    // public IActionResult AddStudent(int id, string firstName, string lastName, DateTime dob, string address, Class classId)
    // {
    //     var add = _DBContext.Student.Add(x => x.ID,
    //         new Student() { ID = id, FirstName = firstName, LastName = lastName, DateOfBirth = dob, Address = address, Grade = classId }
    //     );

    //     return Ok(add);
    // }




    //Add student

    //Get an individual student with Id 

    //Get all students in a grade 

    //Get all students 

}







