using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace StageTracker.Interfaces.Services
{
    public interface IUserSessionService
    {
        string Username { get; set; }
        bool IsAdmin { get; set; }
        bool IsTeacher { get; set; }

        int? ClasseId { get; set; }
    }
}
