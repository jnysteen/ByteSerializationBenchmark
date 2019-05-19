using BenchmarkDotNet.Running;
using ByteSerialization;

namespace ByteSerializationBenchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var complex = ComplexType.Create(3, 3);

            var converter = new JsonByteConverter<ComplexType>();
            var serialized = converter.GetBytes(complex);
            
            
//            var summary1 = BenchmarkRunner.Run<StringByteSerializationBenchmarker>();
            var summary2 = BenchmarkRunner.Run<ComplexTypeSerializationBenchmark>();
        }
    }
}