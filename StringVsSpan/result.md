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