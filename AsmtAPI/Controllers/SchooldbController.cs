using Microsoft.AspNetCore.Mvc;
using AsmtAPI.Data;

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

    public ErrorOr<Created> AddStudent() { return Results.Created; } //Add student

    //Get all students 

    //Get all students in a grade 

    //Get an individual student 
}







