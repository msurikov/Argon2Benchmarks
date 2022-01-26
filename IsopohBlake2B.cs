using Isopoh.Cryptography.Blake2b;
using Isopoh.Cryptography.SecureArray;

namespace Argon2Benckmarks
{
    public class IsopohBlake2B
    {
        public static byte[] GetPasswordHash(byte[] passwordBytes, byte[] salt)
        {
            var config = new Blake2BConfig
            {
                Salt = salt.Take(16).ToArray(),
                OutputSizeInBytes = Constants.HashLength,
            };
            return Blake2B.ComputeHash(passwordBytes, config, SecureArray.DefaultCall);
        }
    }
}