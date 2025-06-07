using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StageTrackerAPI.Helpers;

public static class PasswordHelper
{
    public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using var rng = RandomNumberGenerator.Create();
        passwordSalt = new byte[128];
        rng.GetBytes(passwordSalt);

        using var pbkdf2 = new Rfc2898DeriveBytes(password, passwordSalt, 100000, HashAlgorithmName.SHA256);
        passwordHash = pbkdf2.GetBytes(64);
    }


    public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(password, storedSalt, 100000, HashAlgorithmName.SHA256);
        var hash = pbkdf2.GetBytes(64);

        return hash.SequenceEqual(storedHash);
    }
}
