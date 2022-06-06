using Konscious.Security.Cryptography;

namespace HasAlgorithmBenckmarks
{
    public class KonsciousGenerator
    {
        public static byte[] GetPasswordHash_DataDependentAddressing(byte[] passwordBytes, byte[] salt)
        {
            return GetPasswordHash(new Argon2d(passwordBytes), salt);
        }

        public static byte[] GetPasswordHash_DataIndependentAddressing(byte[] passwordBytes, byte[] salt)
        {
            return GetPasswordHash(new Argon2i(passwordBytes), salt);
        }

        public static byte[] GetPasswordHash_HybridAddressing(byte[] passwordBytes, byte[] salt)
        {
            return GetPasswordHash(new Argon2id(passwordBytes), salt);
        }

        private static byte[] GetPasswordHash(Argon2 argon2, byte[] salt)
        {
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = Constants.DegreeOfParallelism;
            argon2.MemorySize = Constants.CountOfMemoryBlocks;
            argon2.Iterations = Constants.NumberOfIterations;
            argon2.KnownSecret = Constants.KnownSecret;
            argon2.AssociatedData = Constants.AssociatedDate;
            return argon2.GetBytes(Constants.HashLength);
        }

    }
}