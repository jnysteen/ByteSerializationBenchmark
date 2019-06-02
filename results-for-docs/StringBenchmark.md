``` ini

BenchmarkDotNet=v0.11.5, OS=macOS Mojave 10.14.5 (18F203) [Darwin 18.6.0]
Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  Job-XRVZPW : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT

Runtime=Core  Toolchain=netcoreapp2.1  

```
|          Method | StringLength |        Mean |      Error |     StdDev | Ratio | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------------:|-----------:|-----------:|------:|-----:|-------:|------:|------:|----------:|
|         Marshal |           50 |    28.89 ns |  0.5974 ns |  0.8941 ns |  0.03 |    1 | 0.0271 |     - |     - |     128 B |
|     MessagePack |           50 |    88.20 ns |  0.5547 ns |  0.4917 ns |  0.08 |    2 | 0.0169 |     - |     - |      80 B |
|            JSON |           50 |   388.26 ns |  1.8003 ns |  1.5959 ns |  0.34 |    3 | 0.3085 |     - |     - |    1456 B |
|        ProtoBuf |           50 |   700.38 ns |  4.0060 ns |  3.7472 ns |  0.61 |    4 | 0.1354 |     - |     - |     640 B |
| BinaryFormatter |           50 | 1,148.06 ns | 10.0069 ns |  9.3605 ns |  1.00 |    5 | 0.5913 |     - |     - |    2792 B |
|                 |              |             |            |            |       |      |        |       |       |           |
|         Marshal |          100 |    33.28 ns |  0.7370 ns |  1.1689 ns |  0.03 |    1 | 0.0474 |     - |     - |     224 B |
|     MessagePack |          100 |    98.11 ns |  0.6833 ns |  0.6392 ns |  0.08 |    2 | 0.0271 |     - |     - |     128 B |
|            JSON |          100 |   452.06 ns |  3.2072 ns |  2.8431 ns |  0.38 |    3 | 0.3390 |     - |     - |    1600 B |
|        ProtoBuf |          100 |   747.12 ns |  5.1617 ns |  4.8283 ns |  0.62 |    4 | 0.1450 |     - |     - |     688 B |
| BinaryFormatter |          100 | 1,203.48 ns | 17.4695 ns | 16.3410 ns |  1.00 |    5 | 0.6008 |     - |     - |    2840 B |
|                 |              |             |            |            |       |      |        |       |       |           |
|         Marshal |          200 |    44.44 ns |  0.7150 ns |  0.6688 ns |  0.03 |    1 | 0.0898 |     - |     - |     424 B |
|     MessagePack |          200 |   130.57 ns |  0.8277 ns |  0.7337 ns |  0.10 |    2 | 0.0491 |     - |     - |     232 B |
|            JSON |          200 |   617.95 ns | 10.2881 ns |  9.6235 ns |  0.47 |    3 | 0.4034 |     - |     - |    1904 B |
|        ProtoBuf |          200 |   797.10 ns |  5.6800 ns |  5.0351 ns |  0.61 |    4 | 0.1669 |     - |     - |     792 B |
| BinaryFormatter |          200 | 1,305.44 ns | 11.8983 ns | 10.5476 ns |  1.00 |    5 | 0.6237 |     - |     - |    2944 B |
