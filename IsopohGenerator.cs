using Isopoh.Cryptography.Argon2;

namespace Argon2Benckmarks
{
    public class IsopohGenerator
    {
        public static byte[] GetPasswordHash(
            byte[] passwordBytes,
            byte[] salt,
            Argon2Type type = Argon2Type.DataIndependentAddressing,
            int? threads = null
        )
        {
            var config = new Argon2Config
            {
                Version = Argon2Version.Nineteen,
                Password = passwordBytes,
                Salt = salt,
                Type = type,
                Threads = threads ?? Environment.ProcessorCount, // higher than "Lanes" doesn't help (or hurt)
                TimeCost = Constants.NumberOfIterations,
                MemoryCost = Constants.CountOfMemoryBlocks,
                Lanes = Constants.DegreeOfParallelism,
                Secret = Constants.KnownSecret,
                AssociatedData = Constants.AssociatedDate,
                HashLength = Constants.HashLength,
            };

            using (var argon2 = new Argon2(config))
            using (var hash = argon2.Hash())
            {
                return hash.Buffer;
            }
        }
    }
}