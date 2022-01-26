using System.Security.Cryptography;

namespace Argon2Benckmarks
{
    public class SHA1CryptoService
    {
        public static byte[] GetPasswordHash(byte[] passwordBytes, byte[] salt)
        {
            using (var hasher = SHA1.Create())
            {
                var bytes = new byte[salt.Length + passwordBytes.Length];
                System.Buffer.BlockCopy(salt, 0, bytes, 0, salt.Length);
                System.Buffer.BlockCopy(passwordBytes, 0, bytes, salt.Length, passwordBytes.Length);
                return hasher.ComputeHash(bytes);
            }
        }
    }
}