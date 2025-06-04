using CommunityToolkit.Mvvm.ComponentModel;
using StageTracker.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StageTracker.Interfaces.Services
{
    public interface IUserSessionService
    {
        string Username { get; set; }
        public ERoles Role { get; set; }
        bool IsAdmin { get; set; }
        bool IsTeacher { get; set; }

        int? ClasseId { get; set; }
    }
}
