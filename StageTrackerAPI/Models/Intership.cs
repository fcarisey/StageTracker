using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTrackerAPI.Models;

public class IntershipDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Address { get; set; } = string.Empty;

    public int StudentId { get; set; }
    public required Student Student { get; set; }

    public int CompanyId { get; set; }
    public required CompanyDto Company { get; set; }
}
