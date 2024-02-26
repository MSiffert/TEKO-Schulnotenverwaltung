namespace Schulnotenverwaltung.Models;

public class CreateStudentModel
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public Guid ClassId { get; set; }
}