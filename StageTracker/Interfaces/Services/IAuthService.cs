namespace StageTracker.WPF.Interfaces.Services;

public interface IAuthService
{
    public void Authenticate(string username, string password);

    public void Logout();

    public bool IsAuthenticated();
}
