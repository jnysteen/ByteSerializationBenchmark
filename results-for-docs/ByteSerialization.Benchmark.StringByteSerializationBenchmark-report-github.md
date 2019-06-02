``` ini

BenchmarkDotNet=v0.11.5, OS=macOS Mojave 10.14.5 (18F203) [Darwin 18.6.0]
Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  Job-UNMZYR : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT

Runtime=Core  Toolchain=netcoreapp2.1  

```
|          Method | StringLength |        Mean |      Error |     StdDev | Ratio | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |------------- |------------:|-----------:|-----------:|------:|-----:|-------:|------:|------:|----------:|
|         Marshal |          100 |    32.24 ns |  0.6299 ns |  0.5892 ns |  0.03 |    1 | 0.0474 |     - |     - |     224 B |
|            UTF8 |          100 |    74.14 ns |  0.2456 ns |  0.2177 ns |  0.06 |    2 | 0.0271 |     - |     - |     128 B |
|     MessagePack |          100 |   100.74 ns |  0.4471 ns |  0.4183 ns |  0.08 |    3 | 0.0271 |     - |     - |     128 B |
|         Unicode |          100 |   118.63 ns |  0.7008 ns |  0.6212 ns |  0.10 |    4 | 0.0474 |     - |     - |     224 B |
|            JSON |          100 |   487.11 ns |  2.8129 ns |  2.4936 ns |  0.41 |    5 | 0.3386 |     - |     - |    1600 B |
|        ProtoBuf |          100 |   737.57 ns |  6.1722 ns |  5.4715 ns |  0.62 |    6 | 0.1450 |     - |     - |     688 B |
| BinaryFormatter |          100 | 1,188.71 ns | 12.7686 ns | 11.3190 ns |  1.00 |    7 | 0.6008 |     - |     - |    2840 B |
