using Microsoft.AspNetCore.Mvc;
using Schulnotenverwaltung.Models;
using Schulnotenverwaltung.Repositories;

namespace Schulnotenverwaltung.Controllers;

[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly StudentRepository _studentRepository;

    public StudentsController(StudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    
    [Route("")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateStudentModel))]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentModel model)
    {
        var entity = await _studentRepository.CreateStudent(model);
        return Ok(entity);
    }
}