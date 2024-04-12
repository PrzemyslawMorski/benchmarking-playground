using BenchmarkDotNet.Running;
using BenchmarkingPlayground;

BenchmarkRunner.Run(typeof(ForEachVsTaskWhenAll).Assembly);