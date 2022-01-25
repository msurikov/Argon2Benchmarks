using Konscious.Security.Cryptography;

namespace Argon2Benckmarks
{
    public class KonsciousGenerator
    {
        public static byte[] GetPasswordHash(byte[] passwordBytes, byte[] salt)
        {
            var argon2 = new Argon2id(passwordBytes)
            {
                Salt = salt,
                DegreeOfParallelism = Constants.DegreeOfParallelism,
                MemorySize = Constants.CountOfMemoryBlocks,
                Iterations = Constants.NumberOfIterations,
                KnownSecret = Constants.KnownSecret,
                AssociatedData = Constants.AssociatedDate,
            };
            return argon2.GetBytes(64);
        }
    }
}