using Microsoft.AspNetCore.Mvc;
using Schulnotenverwaltung.Data;
using Schulnotenverwaltung.Models;
using Schulnotenverwaltung.Repositories;

namespace Schulnotenverwaltung.Controllers;

[Route("[controller]")]
public class ClassesController : ControllerBase
{
    private readonly ClassRepository _repository;

    public ClassesController(ClassRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ClassModel>))]
    public async Task<IActionResult> GetClasses()
    {
        var classes = await _repository.GetClasses();

        return Ok(classes.Select(MapToModel).OrderBy(e => e.Name).ToList());
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClassModel))]
    public async Task<IActionResult> CreateClass([FromBody] CreateClassModel model)
    {
        var entity = await _repository.CreateClass(model);

        return Ok(MapToModel(entity));
    }

    private ClassModel MapToModel(Class entity)
    {
        return new ClassModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Year = entity.Year,
            TeacherName = entity.TeacherName,
            Students = entity.Students.Select(student => new StudentModel
            {
                Id = student.Id,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                ClassId = student.ClassId,
                ExamGrades = entity.Exams.OrderBy(e => e.Description).Select(exam2 => new ExamGradeModel
                {
                    Id = student.ExamGrades.FirstOrDefault(e => e.ExamId == exam2.Id)?.Id,
                    Grade = student.ExamGrades.FirstOrDefault(e => e.ExamId == exam2.Id)?.Grade,
                    ExamId = student.ExamGrades.FirstOrDefault(e => e.ExamId == exam2.Id)?.ExamId
                }).ToList()
            }).ToList(),
            Exams = entity.Exams.Select(exam => new ExamModel
            {
                Id = exam.Id,
                ClassId = exam.ClassId,
                ClassName = exam.Class.Name,
                Description = exam.Description
            }).OrderBy(e => e.Description).ToList()
        };
    }
}