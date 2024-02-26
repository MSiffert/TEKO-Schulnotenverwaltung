using Microsoft.EntityFrameworkCore;
using Schulnotenverwaltung.Data;
using Schulnotenverwaltung.Models;

namespace Schulnotenverwaltung.Repositories;

public class ExamRepository
{
    private readonly GradesDbContext _dbContext;

    public ExamRepository(GradesDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<Exam>> GetExams()
    {
        return await _dbContext.Exams
            .Include(e => e.Class)
            .ToListAsync();
    }
    
    public async Task CreateExam(CreateExamModel model)
    {
        var clss = await _dbContext.Classes.FirstAsync(e => e.Name == model.ClassName);
        
        var entity = new Exam
        {
            ClassId = clss.Id,
            Description = model.Description
        };

        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();
    }
}