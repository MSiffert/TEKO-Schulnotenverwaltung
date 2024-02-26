using Microsoft.EntityFrameworkCore;
using Schulnotenverwaltung.Data;
using Schulnotenverwaltung.Models;

namespace Schulnotenverwaltung.Repositories;

public class ExamGradesRepository
{
    private readonly GradesDbContext _dbContext;

    public ExamGradesRepository(GradesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task UpdateExamGrades(List<UpdateExamGradeModel> models)
    {
        var examGrades = await _dbContext.ExamGrades.ToListAsync();

        foreach (var model in models)
        {
            var existing = examGrades.FirstOrDefault(e => e.ExamId == model.ExamId && e.StudentId == model.StudentId);
            if (existing is not null)
            {
                existing.Grade = model.Grade;
            }
            else
            {
                _dbContext.ExamGrades.Add(new ExamGrade
                {
                    ExamId = model.ExamId,
                    StudentId = model.StudentId,
                    Grade = model.Grade
                });
            }

            await _dbContext.SaveChangesAsync();
        }
    }    
}