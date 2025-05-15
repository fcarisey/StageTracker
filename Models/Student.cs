using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTracker.Models;

public class Student
{
    public required int Id { get; set; }
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public string? FullName => $"{FirstName} {LastName}";
    public string? Classe { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }

    public Collection<Intership> Internships { get; set; } = [];

    public Collection<Application> Applications { get; set; } = [];

    public bool HasInternship => Internships.Count > 0;

    public bool HasApplication => Applications.Count > 0;

}
