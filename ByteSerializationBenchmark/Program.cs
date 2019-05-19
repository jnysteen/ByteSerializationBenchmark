using BenchmarkDotNet.Running;

namespace ByteSerializationBenchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<StringByteSerializationBenchmarker>();
        }
    }
}