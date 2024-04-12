using BenchmarkDotNet.Attributes;

namespace BenchmarkingPlayground.ForEachVsTaskWhenAll;

public class ForEachVsTaskWhenAll
{
    private const int NumIterations = 500;
    
    private Task Method1Async()
    {
        return Task.Run(() =>
        {
            int.MaxValue.ToString();
            var y = 1231231111111111123 - 12308120381293;
            var z = y * 123123123123123123;
            var xx = z.ToString();
        });
    }

    [Benchmark]
    public async Task ForEachLoopAsync()
    {
        var loop = Enumerable.Range(1, NumIterations);

        foreach (var l in loop)
        {
            await Method1Async().ConfigureAwait(false);
        }
    }

    [Benchmark]
    public async Task ForEachMethodAsync()
    {
        var loop = Enumerable.Range(1, NumIterations).ToList();
        loop.ForEach(async _ => await Method1Async());
    }

    [Benchmark]
    public Task TaskWhenAllAsync()
    {
        // Task.WhenAll will lose the order of the tasks, also exception/failure handling is more complicated, but could use FluentResults for that
        return Task.WhenAll(Enumerable.Range(1, NumIterations).Select(_ => Method1Async()));
    }
}