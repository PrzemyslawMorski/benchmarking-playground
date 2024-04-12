using BenchmarkDotNet.Attributes;

namespace BenchmarkingPlayground.StringVsSpan;

[MemoryDiagnoser]
public class StringVsSpan
{
    private const string DateTime = "02 08 2024";

    [Benchmark]
    public (int day, int month, int year) SubString()
    {
        var dayAsText = DateTime[..2];
        var monthAsText = DateTime.Substring(3, 2);
        var yearAsText = DateTime[6..];
        return (int.Parse(dayAsText), int.Parse(monthAsText), int.Parse(yearAsText));
    }

    [Benchmark]
    public (int day, int month, int year) Span()
    {
        var span = DateTime.AsSpan();
        var dayAsText = span[..2];
        var monthAsText = span.Slice(3, 2);
        var yearAsText = span[6..];
        return (int.Parse(dayAsText), int.Parse(monthAsText), int.Parse(yearAsText));
    }
}