using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<HasAlgorithmBenckmarks.Benchmarks>(
    ManualConfig
        .Create(DefaultConfig.Instance)
        //.WithOptions(ConfigOptions.DisableOptimizationsValidator)
);
