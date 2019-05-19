using BenchmarkDotNet.Running;
using ByteSerialization;

namespace ByteSerializationBenchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<StringByteSerializationBenchmarker>();
            BenchmarkRunner.Run<ComplexTypeSerializationBenchmark>();
        }
    }
}