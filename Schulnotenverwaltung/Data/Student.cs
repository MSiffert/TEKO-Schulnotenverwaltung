namespace Schulnotenverwaltung.Data;

public class Student
{
    public Student()
    {
        ExamGrades = new List<ExamGrade>();
    }
    
    public Guid Id { get; set; }
    
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    
    public Class Class { get; set; }
    public Guid ClassId { get; set; }
    
    public ICollection<ExamGrade> ExamGrades { get; set; }
}