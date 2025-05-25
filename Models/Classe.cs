using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTracker.Models;

public class Classe
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public Collection<Student> Students { get; set; } = [];

    public bool HasStudents => Students.Count > 0;

    public Teacher? Teacher { get; set; }
}
