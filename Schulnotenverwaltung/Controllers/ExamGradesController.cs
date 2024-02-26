using Microsoft.AspNetCore.Mvc;
using Schulnotenverwaltung.Models;
using Schulnotenverwaltung.Repositories;

namespace Schulnotenverwaltung.Controllers;

[Route("[controller]")]
public class ExamGradesController : ControllerBase
{
    private readonly ExamGradesRepository _repository;

    public ExamGradesController(ExamGradesRepository repository)
    {
        _repository = repository;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> SaveExamGrades([FromBody] List<UpdateExamGradeModel> model)
    {
        await _repository.UpdateExamGrades(model);
        return Ok();
    }
}