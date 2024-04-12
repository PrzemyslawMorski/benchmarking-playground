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