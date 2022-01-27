namespace Argon2Benckmarks
{
    public static class Constants
    {
        public const int SaltLength = 64;
        public const int HashLength = 64;
        public const int NumberOfIterations = 1; //3;
        public const int CountOfMemoryBlocks = 1*1024; //16*1024;
        public const int DegreeOfParallelism = 1; //4;
        public const byte[] KnownSecret = null;
        public const byte[] AssociatedDate = null;
    }
}