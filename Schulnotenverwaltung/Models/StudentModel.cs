namespace Schulnotenverwaltung.Models;

public class StudentModel
{
    public StudentModel()
    {
        ExamGrades = new List<ExamGradeModel>();
    }
    
    public Guid Id { get; set; }
    
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public Guid ClassId { get; set; }
    
    public ICollection<ExamGradeModel> ExamGrades { get; set; }
}