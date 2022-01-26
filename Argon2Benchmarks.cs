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
            _salt = new byte[64];
            new Random().NextBytes(_salt);
        }

        [Benchmark]
        public byte[] SHA1PasswordHash() => SHA1CryptoService.GetPasswordHash(_passwordBytes, _salt);

        [Benchmark]
        public byte[] Blake2PasswordHash() => Blake2Hasher.GetPasswordHash(_passwordBytes, _salt);

        [Benchmark]
        public byte[] Blake3PasswordHash() => Blake3Hasher.GetPasswordHash(_passwordBytes, _salt);

        [Benchmark]
        public byte[] Konscious_Argon2d() => KonsciousGenerator.GetPasswordHash_DataDependentAddressing(_passwordBytes, _salt);

        [Benchmark]
        public byte[] Konscious_Argon2i() => KonsciousGenerator.GetPasswordHash_DataIndependentAddressing(_passwordBytes, _salt);

        [Benchmark]
        public byte[] Konscious_Argon2id() => KonsciousGenerator.GetPasswordHash_HybridAddressing(_passwordBytes, _salt);

        [Benchmark]
        public byte[] Konscious_Blake2B() => KonsciousBlake2B.GetPasswordHash(_passwordBytes, _salt);

        [Benchmark]
        public byte[] Isopoh_Argon2d() => IsopohGenerator.GetPasswordHash(_passwordBytes, _salt, Argon2Type.DataDependentAddressing);

        [Benchmark]
        public byte[] Isopoh_Argon2i() => IsopohGenerator.GetPasswordHash(_passwordBytes, _salt, Argon2Type.DataIndependentAddressing);

        [Benchmark]
        public byte[] Isopoh_Argon2id() => IsopohGenerator.GetPasswordHash(_passwordBytes, _salt, Argon2Type.HybridAddressing);

        [Benchmark]
        public byte[] Isopoh_Blake2B() => IsopohBlake2B.GetPasswordHash(_passwordBytes, _salt);
    }
}