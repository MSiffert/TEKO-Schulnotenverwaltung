namespace Schulnotenverwaltung.Models;

public class ExamModel
{
    public Guid Id { get; set; }
    public Guid ClassId { get; set; }
    public string ClassName { get; set; }
    public string Description { get; set; }
}