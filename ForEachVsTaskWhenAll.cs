using BenchmarkDotNet.Attributes;

namespace BenchmarkingPlayground;

public class ForEachVsTaskWhenAll
{
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
        var loop = Enumerable.Range(1, 50);

        foreach (var l in loop)
        {
            await Method1Async().ConfigureAwait(false);
        }
    }

    [Benchmark]
    public async Task ForEachMethodAsync()
    {
        var loop = Enumerable.Range(1, 50).ToList();
        loop.ForEach(async _ => await Method1Async());
    }

    [Benchmark]
    public Task TaskWhenAllAsync()
    {
        return Task.WhenAll(Enumerable.Range(1, 50).Select(_ => Method1Async()));
    }
}