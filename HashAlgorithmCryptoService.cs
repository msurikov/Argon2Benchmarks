using System.Security.Cryptography;

namespace HasAlgorithmBenckmarks
{
    public class HashAlgorithmCryptoService
    {
        public static byte[] GetPasswordHash(byte[] passwordBytes, byte[] salt, string hashName)
        {
            using (var hasher = HashAlgorithm.Create(hashName)!)
            {
                var bytes = new byte[salt.Length + passwordBytes.Length];
                System.Buffer.BlockCopy(salt, 0, bytes, 0, salt.Length);
                System.Buffer.BlockCopy(passwordBytes, 0, bytes, salt.Length, passwordBytes.Length);
                return hasher.ComputeHash(bytes);
            }
        }
    }
}