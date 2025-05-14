using System;
using System.Collections.Generic;
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
    public string? Mail { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }

}
