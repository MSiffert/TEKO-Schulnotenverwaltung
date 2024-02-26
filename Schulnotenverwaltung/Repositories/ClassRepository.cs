using Microsoft.EntityFrameworkCore;
using Schulnotenverwaltung.Data;
using Schulnotenverwaltung.Models;

namespace Schulnotenverwaltung.Repositories;

public class ClassRepository
{
    private readonly GradesDbContext _dbContext;

    public ClassRepository(GradesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Class>> GetClasses()
    {
        return await _dbContext.Classes
            .Include(e => e.Students).ThenInclude(e => e.ExamGrades)
            .Include(e => e.Exams)
            .ToListAsync();
    }

    public async Task<Class> CreateClass(CreateClassModel model)
    {
        var entity = new Class
        {
            Name = model.Name,
            Year = model.Year,
            TeacherName = model.TeacherName
        };

        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }
}