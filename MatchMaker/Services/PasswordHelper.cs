using Microsoft.AspNetCore.Identity;

namespace MatchMaker.Services
{
    public class PasswordHelper
    {
        private readonly PasswordHasher<object> hasher = new PasswordHasher<object>();

        public string HashPassword(string password)
        {
            return hasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string inputPassword)
        {
            var result = hasher.VerifyHashedPassword(null, hashedPassword, inputPassword);
            return result == PasswordVerificationResult.Success;
        }
    }

}
