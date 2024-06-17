Notes:

- The `String` type is a reference type, and the `Span` type is a value type.
- Span has some limitations, such as it cannot be used in async methods
- Span is a great way to reduce the amount of memory used by unnecessary string objects on the heap, and it is a great
  way to reduce the amount of memory used by unnecessary string objects on the heap.
- If you perform a .ToString() on a Span, it will create a new string object on the heap, losing all the benefit of
  using the span in the first place.

| Method    |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|-----------|---------:|---------:|---------:|-------:|----------:|
| SubString | 46.49 ns | 0.790 ns | 0.659 ns | 0.0153 |      96 B |
| Span      | 27.04 ns | 0.570 ns | 0.799 ns |      - |         - |

# Documentation: String Manipulation with [Substring](file:///c%3A/Users/Lenovo/RiderProjects/benchmarking-playground/StringVsSpan/ForEachVsTaskWhenAll.cs#14%2C36-14%2C36) and `Span<T>`

## Overview
This documentation provides an overview of two common methods for manipulating strings in .NET: using [Substring](file:///c%3A/Users/Lenovo/RiderProjects/benchmarking-playground/StringVsSpan/ForEachVsTaskWhenAll.cs#14%2C36-14%2C36) and `Span<T>`. Understanding the differences between these two approaches is crucial for optimizing performance and memory usage in applications that involve heavy string manipulation.

## Table of Contents
- [Introduction](#introduction)
- [Using Substring](#using-substring)
- [Using Span<T>](#using-span<t>)
- [Performance Comparison](#performance-comparison)
- [Use Case Scenarios](#use-case-scenarios)
- [Conclusion](#conclusion)

## Introduction
Strings are immutable in .NET, which means every time a string is modified, a new string is created. This can lead to performance issues in applications that require extensive string manipulation. [Substring](file:///c%3A/Users/Lenovo/RiderProjects/benchmarking-playground/StringVsSpan/ForEachVsTaskWhenAll.cs#14%2C36-14%2C36) and `Span<T>` provide two different ways to handle string data, each with its own advantages and limitations.

## Using Substring
[Substring](file:///c%3A/Users/Lenovo/RiderProjects/benchmarking-playground/StringVsSpan/ForEachVsTaskWhenAll.cs#14%2C36-14%2C36) is a method available on the [string](file:///c%3A/Users/Lenovo/RiderProjects/benchmarking-playground/StringVsSpan/ForEachVsTaskWhenAll.cs#8%2C19-8%2C19) class that returns a new string containing a portion of the original string.

### Syntax
```csharp
public string Substring(int startIndex, int length)
```

### Example
```csharp
string date = "02 08 2024";
string month = date.Substring(3, 2); // Extracts "08"
```

### Advantages
- Simple and familiar to most C# developers.
- Useful when a new string is needed.

### Disadvantages
- Creates a new string, leading to additional memory allocation.
- Can be less efficient in performance-critical applications.

## Using Span<T>
`Span<T>` is a type introduced in .NET Core to manage slices of memory. For strings, `Span<char>` provides a way to view portions of strings without creating new ones.

### Syntax
```csharp
public ReadOnlySpan<char> AsSpan(int start, int length)
```

### Example
```csharp
string date = "02 08 2024";
ReadOnlySpan<char> monthSpan = date.AsSpan(3, 2);
int month = int.Parse(monthSpan); // Directly parses "08" from the span
```

### Advantages
- Does not allocate additional memory for slices.
- Offers better performance, especially in scenarios involving large data manipulation.

### Disadvantages
- `Span<T>` instances cannot be stored in fields of heap-allocated objects.
- Slightly more complex usage compared to traditional string methods.

## Performance Comparison
Benchmarking studies typically show that `Span<T>` outperforms `Substring` in both speed and memory efficiency, particularly in tight loops or when processing large volumes of data.

## Use Case Scenarios
- **Substring**: Best for scenarios where the manipulated strings need to be passed around or persisted outside the scope of the current method.
- **Span<T>**: Ideal for high-performance parsing and in-memory data processing where temporary views of data are sufficient.

## Conclusion
Choosing between `Substring` and `Span<T>` depends on the specific requirements of the application. For high-performance and memory-efficient applications, `Span<T>` is generally the preferred choice. However, for applications where string manipulation is minimal or where new strings need to be created, `Substring` remains a viable option.