using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Argon2Benckmarks.Benchmarks>(
    ManualConfig
        .Create(DefaultConfig.Instance)
        //.WithOptions(ConfigOptions.DisableOptimizationsValidator)
);
