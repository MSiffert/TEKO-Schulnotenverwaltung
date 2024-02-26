namespace Schulnotenverwaltung.Data;

public class Class
{
    public Class()
    {
        Students = new List<Student>();
        Exams = new List<Exam>();
    }
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string TeacherName { get; set; }
    
    public ICollection<Student> Students { get; set; }
    public ICollection<Exam> Exams { get; set; }
}