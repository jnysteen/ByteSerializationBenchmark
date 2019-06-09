using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using ByteSerialization.StringOnly;

namespace ByteSerialization.Benchmark
{
    /// <summary>
    /// Benchmarks the implementations' performances when serializing strings
    /// </summary>
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [EncodingAttribute.Unicode]
    [MarkdownExporter, RPlotExporter]
    public class StringByteSerializationBenchmark
    {
        /// <summary>
        /// The lengths of the string, that the implementations will serialize
        /// </summary>
        [Params(100)]
        public int StringLength { get; set; }
        
        /// <summary>
        /// The converter used in each benchmark
        /// </summary>
        public IByteConverter<string> Converter { get; set; }
        
        /// <summary>
        /// The actual input to the serializer implementations
        /// </summary>
        public string TestString { get; set; }

        /// <summary>
        /// Produce the actual test string
        /// </summary>
        private string GetTestString()
        {
            return new string('a', StringLength);
        }
        
        
        [GlobalSetup(Target = nameof(BinaryFormatterByteConverterBenchmark))]
        public void Setup_BinaryFormatterByteConverter()
        {
            Converter = new BinaryFormatterByteConverter<string>();
            TestString = GetTestString();
        }
        
        [Benchmark(Baseline = true, Description = "BinaryFormatter")]
        public void BinaryFormatterByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
        
        
        [GlobalSetup(Target = nameof(JsonByteConverterBenchmark))]
        public void Setup_JsonByteConverter()
        {
            Converter = new JsonByteConverter<string>();
            TestString = GetTestString();
        }
        
        [Benchmark(Description = "JSON")]
        public void JsonByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
        
        
        [GlobalSetup(Target = nameof(MarshalByteConverterBenchmark))]
        public void Setup_MarshalByteConverter()
        {
            Converter = new MarshalByteConverter();
            TestString = GetTestString();
        }
        
        [Benchmark(Description = "Marshal")]
        public void MarshalByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
        
        
        [GlobalSetup(Target = nameof(ProtoBufByteConverterBenchmark))]
        public void Setup_ProtoBufByteConverter()
        {
            Converter = new ProtoBufByteConverter<string>();
            TestString = GetTestString();
        }
        
        [Benchmark(Description = "ProtoBuf")]
        public void ProtoBufByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
        
        
        [GlobalSetup(Target = nameof(MessagePackByteConverterBenchmark))]
        public void Setup_MessagePackByteConverter()
        {
            Converter = new MessagePackByteConverter<string>();
            TestString = GetTestString();
        }
        
        [Benchmark(Description = "MessagePack")]
        public void MessagePackByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
        
        
        [GlobalSetup(Target = nameof(UnicodeByteConverterBenchmark))]
        public void Setup_UnicodeByteConverter()
        {
            Converter = new UnicodeByteConverter();
            TestString = GetTestString();
        }
        
        [Benchmark(Description = "Unicode")]
        public void UnicodeByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
        
        
        [GlobalSetup(Target = nameof(Utf8ByteConverterBenchmark))]
        public void Setup_Utf8ByteConverter()
        {
            Converter = new Utf8ByteConverter();
            TestString = GetTestString();
        }
        
        [Benchmark(Description = "UTF8")]
        public void Utf8ByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
    }
}