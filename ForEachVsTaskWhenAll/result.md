Notes:

- The `ForEach` method is a synchronous method that iterates over a collection of tasks and awaits each task in the collection.
- The `Task.WhenAll` method is an asynchronous method that takes a collection of tasks and returns a task that represents the completion of all the tasks in the collection.
- Task.WhenAll is more efficient than the ForEach method because it doesn't wait for each task to complete before moving on to the next task.
- However, Task.WhenAll is not always the best choice. If you need to process the results of each task as they complete, and in a specific order, you may want to use the ForEach method instead.

Number of iterations: 50

| Method             |     Mean |    Error |   StdDev |
|--------------------|---------:|---------:|---------:|
| ForEachLoopAsync   | 39.81 us | 0.793 us | 1.451 us |
| ForEachMethodAsync | 24.05 us | 0.475 us | 0.444 us |
| TaskWhenAllAsync   | 16.00 us | 0.218 us | 0.204 us |

Number of iterations: 500


| Method             | Mean     | Error   | StdDev   |
|------------------- |---------:|--------:|---------:|
| ForEachLoopAsync   | 294.8 us | 5.87 us | 11.59 us |
| ForEachMethodAsync | 237.8 us | 4.76 us |  6.82 us |
| TaskWhenAllAsync   | 130.8 us | 3.06 us |  9.02 us |

# Documentation for [ForEachVsTaskWhenAll.cs](file:///c%3A/Users/Lenovo/RiderProjects/benchmarking-playground/StringVsSpan/ForEachVsTaskWhenAll.cs#1%2C1-1%2C1)

## Overview
The [ForEachVsTaskWhenAll.cs](file:///c%3A/Users/Lenovo/RiderProjects/benchmarking-playground/StringVsSpan/ForEachVsTaskWhenAll.cs#1%2C1-1%2C1) file contains benchmarks that compare the performance of three different methods for handling multiple asynchronous tasks in C#. The methods compared are:

1. **ForEachLoopAsync**
2. **ForEachMethodAsync**
3. **TaskWhenAllAsync**

## Methods Description

### 1. ForEachLoopAsync
- Iterates over a range of numbers using a [foreach](file:///c%3A/Users/Lenovo/RiderProjects/benchmarking-playground/ForEachVsTaskWhenAll/ForEachVsTaskWhenAll.cs#25%2C9-25%2C9) loop.
- Awaits the completion of an asynchronous method ([Method1Async](file:///c%3A/Users/Lenovo/RiderProjects/benchmarking-playground/ForEachVsTaskWhenAll/ForEachVsTaskWhenAll.cs#9%2C18-9%2C18)) in each iteration.
- Processes tasks sequentially.

### 2. ForEachMethodAsync
- Utilizes `List.ForEach` to execute the asynchronous [Method1Async](file:///c%3A/Users/Lenovo/RiderProjects/benchmarking-playground/ForEachVsTaskWhenAll/ForEachVsTaskWhenAll.cs#9%2C18-9%2C18) method for each item in a list.
- Tasks are not awaited as a group, which can lead to issues with task orchestration.

### 3. TaskWhenAllAsync
- Employs `Task.WhenAll` to await the completion of all tasks initiated over a range of numbers concurrently.
- Offers the most efficient completion time for all tasks.

## Benchmark Results
The benchmarks demonstrate the efficiency gains from using `Task.WhenAll` for concurrent task processing compared to sequential processing with [foreach](file:///c%3A/Users/Lenovo/RiderProjects/benchmarking-playground/ForEachVsTaskWhenAll/ForEachVsTaskWhenAll.cs#25%2C9-25%2C9).

```markdown
| Method             | Mean     | Error   | StdDev   |
|--------------------|---------:|--------:|---------:|
| ForEachLoopAsync   | 294.8 us | 5.87 us | 11.59 us |
| ForEachMethodAsync | 237.8 us | 4.76 us |  6.82 us |
| TaskWhenAllAsync   | 130.8 us | 3.06 us |  9.02 us |
```

## Conclusion
The `TaskWhenAllAsync` method significantly outperforms the other methods in terms of total completion time, demonstrating the advantages of concurrent task processing in appropriate scenarios.