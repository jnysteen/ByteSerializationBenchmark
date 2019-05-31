using BenchmarkDotNet.Running;

namespace ByteSerialization.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<StringByteSerializationBenchmarker>();
//            BenchmarkRunner.Run<ComplexTypeSerializationBenchmark>();
        }
    }
}