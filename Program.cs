using BenchmarkDotNet.Running;
using BenchmarkingPlayground;
using BenchmarkingPlayground.ForEachVsTaskWhenAll;
using BenchmarkingPlayground.StringVsSpan;

BenchmarkRunner.Run(typeof(StringVsSpan).Assembly);