using Microsoft.AspNetCore.Mvc;
using Schulnotenverwaltung.Data;
using Schulnotenverwaltung.Models;
using Schulnotenverwaltung.Repositories;

namespace Schulnotenverwaltung.Controllers;

[Route("[controller]")]
public class ExamsController : ControllerBase
{
    private readonly ExamRepository _repository;

    public ExamsController(ExamRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExamModel))]
    public async Task<IActionResult> GetExams()
    {
        var exams = await _repository.GetExams();

        return Ok(exams.Select(MapToModel).ToList());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateExam([FromBody] CreateExamModel model)
    {
        await _repository.CreateExam(model);

        return Ok();
    }

    private ExamModel MapToModel(Exam entity)
    {
        return new ExamModel
        {
            Id = entity.Id,
            ClassId = entity.ClassId,
            Description = entity.Description,
            ClassName = entity.Class.Name,
        };
    }
}