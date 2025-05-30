using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTrackerAPI.Models;

public class Teacher
{
    public int Id { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;

    public string FullName => $"{LastName} {FirstName}";

    public int? ClasseId { get; set; }
    public ClasseDto? Classe { get; set; }
}
