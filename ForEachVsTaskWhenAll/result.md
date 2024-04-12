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