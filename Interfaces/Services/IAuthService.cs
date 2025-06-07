using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StageTracker.Interfaces.Services;

public interface IAuthService
{
    public void Authenticate(string username, string password);

    public void Logout();

    public bool IsAuthenticated();
}
