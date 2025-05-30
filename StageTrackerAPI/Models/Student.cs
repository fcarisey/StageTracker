using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTrackerAPI.Models;

public class Student
{
    public int Id { get; set; }
    public required string LastName { get; set; }
    public required string FirstName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public int? ClasseId { get; set; }
    public ClasseDto? Classe { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public Collection<IntershipDto> Internships { get; set; } = [];

    public Collection<Application> Applications { get; set; } = [];

    public Collection<RemarkDto> Remarks { get; set; } = [];

    public bool HasInternship => Internships.Count > 0;

    public bool HasApplication => Applications.Count > 0;

    public bool HasRemark => Remarks.Count > 0;

}
