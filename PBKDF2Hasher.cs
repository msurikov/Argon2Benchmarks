namespace Argon2Benckmarks
{
    public class PBKDF2Hasher
    {
        public static byte[] GetPasswordHash(byte[] passwordBytes, byte[] salt, int iterations = Constants.WorkFactor)
        {
            var hasher = new System.Security.Cryptography.Rfc2898DeriveBytes(passwordBytes, salt, iterations);
            return hasher.GetBytes(Constants.HashLength);
        }
    }
}