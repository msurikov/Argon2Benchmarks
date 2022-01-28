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
            _passwordBytes = System.Text.Encoding.UTF8.GetBytes("Enough long password with special characters like !@#$%^&*() and digits 0123456789 for benchmark");
            _salt = new byte[64];
            new Random().NextBytes(_salt);
        }

        // [Benchmark]
        // public byte[] SHA1() => SHA1CryptoService.GetPasswordHash(_passwordBytes, _salt);

        [Benchmark]
        public byte[] PBKDF2_1000() => PBKDF2Hasher.GetPasswordHash(_passwordBytes, _salt, iterations: 1000);

        [Benchmark]
        public byte[] PBKDF2_10000() => PBKDF2Hasher.GetPasswordHash(_passwordBytes, _salt, iterations: 10000);

        [Benchmark]
        public byte[] PBKDF2_100000() => PBKDF2Hasher.GetPasswordHash(_passwordBytes, _salt, iterations: 100000);

        [Benchmark]
        public byte[] PBKDF2_310000() => PBKDF2Hasher.GetPasswordHash(_passwordBytes, _salt, iterations: 310000);


        [Benchmark]
        public byte[] Konscious_Argon2d() => KonsciousGenerator.GetPasswordHash_DataDependentAddressing(_passwordBytes, _salt);

        [Benchmark]
        public byte[] Konscious_Argon2i() => KonsciousGenerator.GetPasswordHash_DataIndependentAddressing(_passwordBytes, _salt);

        [Benchmark]
        public byte[] Konscious_Argon2id() => KonsciousGenerator.GetPasswordHash_HybridAddressing(_passwordBytes, _salt);

        [Benchmark]
        public byte[] Isopoh_Argon2d() => IsopohGenerator.GetPasswordHash(_passwordBytes, _salt, Argon2Type.DataDependentAddressing);

        [Benchmark]
        public byte[] Isopoh_Argon2i() => IsopohGenerator.GetPasswordHash(_passwordBytes, _salt, Argon2Type.DataIndependentAddressing);

        [Benchmark]
        public byte[] Isopoh_Argon2id() => IsopohGenerator.GetPasswordHash(_passwordBytes, _salt, Argon2Type.HybridAddressing);
    }
}