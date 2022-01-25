using BenchmarkDotNet.Attributes;
using Isopoh.Cryptography.Argon2;

namespace Argon2Benckmarks
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        private byte[] _passwordBytes;
        private byte[] _salt;

        public Benchmarks()
        {
            _passwordBytes = System.Text.Encoding.UTF8.GetBytes("password1");
            _salt = new byte[16];
            new Random().NextBytes(_salt);
        }

        [Benchmark]
        public byte[] KonsciousPasswordHash() => KonsciousGenerator.GetPasswordHash(_passwordBytes, _salt);

        [Benchmark]
        public byte[] IsopohPasswordHash_HybridAddressing() => IsopohGenerator.GetPasswordHash(_passwordBytes, _salt, Argon2Type.HybridAddressing);

        [Benchmark]
        public byte[] IsopohPasswordHash_DataDependentAddressing() => IsopohGenerator.GetPasswordHash(_passwordBytes, _salt, Argon2Type.DataDependentAddressing);

        [Benchmark]
        public byte[] IsopohPasswordHash_DataIndependentAddressing() => IsopohGenerator.GetPasswordHash(_passwordBytes, _salt, Argon2Type.DataIndependentAddressing);
    }
}