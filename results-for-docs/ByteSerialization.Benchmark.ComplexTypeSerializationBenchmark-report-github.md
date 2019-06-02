``` ini

BenchmarkDotNet=v0.11.5, OS=macOS Mojave 10.14.5 (18F203) [Darwin 18.6.0]
Intel Core i7-8850H CPU 2.60GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=2.2.300
  [Host]     : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT
  Job-UNMZYR : .NET Core 2.2.5 (CoreCLR 4.6.27617.05, CoreFX 4.6.27618.01), 64bit RyuJIT

Runtime=Core  Toolchain=netcoreapp2.1  

```
|          Method |       Mean |     Error |    StdDev | Ratio | Rank |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |-----------:|----------:|----------:|------:|-----:|-------:|------:|------:|----------:|
|        ProtoBuf |   3.188 μs | 0.0123 μs | 0.0115 μs |  0.03 |    1 | 0.4959 |     - |     - |   2.29 KB |
|     MessagePack |   3.859 μs | 0.0321 μs | 0.0300 μs |  0.03 |    2 | 0.3662 |     - |     - |    1.7 KB |
|            JSON |  26.522 μs | 0.2068 μs | 0.1833 μs |  0.23 |    3 | 1.8616 |     - |     - |   8.66 KB |
| BinaryFormatter | 116.973 μs | 0.4336 μs | 0.3621 μs |  1.00 |    4 | 9.0332 |     - |     - |  41.67 KB |
