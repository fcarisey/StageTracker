using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTrackerAPI.Interfaces.Services
{
    public interface IUserSessionService
    {
        string Username { get; set; }
        bool IsAdmin { get; set; }
        bool IsTeacher { get; set; }

        int? ClasseId { get; set; }
    }
}
