namespace Argon2Benckmarks
{
    public static class Constants
    {
        public const int SaltLength = 64;
        public const int HashLength = 64;
        public const int NumberOfIterations = 3;
        public const int CountOfMemoryBlocks = 65536;
        public const int DegreeOfParallelism = 4;
        public const byte[] KnownSecret = null;
        public const byte[] AssociatedDate = null;
    }
}