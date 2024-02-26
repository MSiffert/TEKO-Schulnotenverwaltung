using Schulnotenverwaltung.Data;

namespace Schulnotenverwaltung.Models;

public class ClassModel
{
    public ClassModel()
    {
        Students = new List<StudentModel>();
        Exams = new List<ExamModel>();
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public string TeacherName { get; set; }

    public List<StudentModel> Students { get; set; }
    public List<ExamModel> Exams { get; set; }

}