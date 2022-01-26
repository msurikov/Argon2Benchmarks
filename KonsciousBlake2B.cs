using Konscious.Security.Cryptography;

namespace Argon2Benckmarks
{
    public class KonsciousBlake2B
    {
        public static byte[] GetPasswordHash(byte[] passwordBytes, byte[] salt)
        {
            using (var hasher = new HMACBlake2B(salt, 8*Constants.HashLength))
            {
                return hasher.ComputeHash(passwordBytes);
            }
        }
    }
}