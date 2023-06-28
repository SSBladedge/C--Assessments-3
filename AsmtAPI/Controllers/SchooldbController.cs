using Microsoft.AspNetCore.Mvc;
using AsmtAPI.Data;
using AsmtAPI.Models;
using AsmtAPI.Models.DTO;


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
    public IEnumerable<StudentDTOList> GetAllStudents()
    {
        var records = (from students in _DBContext.Student
                       select new StudentDTOList
                       {
                           ID = students.ID,
                           FirstName = students.FirstName,
                           LastName = students.LastName,
                           Grade = students.Grade
                       }).ToArray();

        return records;
    }

    [HttpGet(Name = "Get student records by grade")]
    [Route("{gradeStart:int}/{gradeEnd:int}")]
    public IEnumerable<StudentDTOList> GetStudentsByGrade(int gradeStart, int gradeEnd)
    {
        var records = (from students in _DBContext.Student
                       where gradeStart <= (int)students.Grade.GradeLevel &&
                       (int)students.Grade.GradeLevel <= gradeEnd
                       select new StudentDTOList
                       {
                           ID = students.ID,
                           FirstName = students.FirstName,
                           LastName = students.LastName,
                           Grade = students.Grade
                       }).ToArray();


        return records;
    }

    [HttpGet(Name = "Get student record using id")]
    [Route("{id:int}")]
    public Student GetStudentById(int id)
    {
        Student student = new Student();

        try
        {
            if (id < 0)
                throw new Exception("Student ID must be greater than zero"); //ID value range is checked here for user unput !!!!

            student = ((from students in _DBContext.Student
                        where students.ID == id
                        select students).FirstOrDefault())!;
        }
        catch
        {
            throw new Exception("Student ID not found");
        }

        return student;
    }

    [HttpPost]
    public bool RegisterStudent(Student student)
    {
        try
        {
            if (string.IsNullOrEmpty(student.FirstName))
                throw new Exception("Student first name is required");

            if (string.IsNullOrEmpty(student.LastName))
                throw new Exception("Student last name is required");

            var checkForStudent = (from students in _DBContext.Student
                                   where students.FirstName.Equals(student.FirstName) &&
                                   students.LastName.Equals(student.LastName)
                                   select students).Count();      //Revise function to end the moment record is found 

            if (checkForStudent > 0)
                throw new Exception("Student record already exists");

            _DBContext.Student.Add(student);
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return true;
    }


    //RESOLVE INTERACTIONS BETWEEN CLASS CLASS AND STUDENT CLASS 

}







