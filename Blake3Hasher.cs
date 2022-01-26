namespace Argon2Benckmarks
{
    public class Blake3Hasher
    {
        public static byte[] GetPasswordHash(byte[] passwordBytes, byte[] salt)
        {
            var hasher = new Blake3Core.Blake3();
            var bytes = new byte[salt.Length + passwordBytes.Length];
            System.Buffer.BlockCopy(salt, 0, bytes, 0, salt.Length);
            System.Buffer.BlockCopy(passwordBytes, 0, bytes, salt.Length, passwordBytes.Length);
            return hasher.ComputeHash(bytes);
        }
    }
}