using Schulnotenverwaltung.Data;
using Schulnotenverwaltung.Models;

namespace Schulnotenverwaltung.Repositories;

public class StudentRepository
{
    private readonly GradesDbContext _dbContext;

    public StudentRepository(GradesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Student> CreateStudent(CreateStudentModel model)
    {
        var entity = new Student
        {
            Id = Guid.NewGuid(),
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            ClassId = model.ClassId
        };

        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }
}