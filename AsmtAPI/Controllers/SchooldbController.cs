using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {

    }
}







