using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using ByteSerialization.StringOnly;

namespace ByteSerialization.Benchmark
{
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [EncodingAttribute.Unicode]
    [MarkdownExporter, RPlotExporter]
    public class StringByteSerializationBenchmark
    {
        [Params(100)]
        public int StringLength { get; set; }
        public IByteConverter<string> Converter { get; set; }
        public string TestString { get; set; }

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
        
        [GlobalSetup(Target = nameof(JsonByteConverterBenchmark))]
        public void Setup_JsonByteConverter()
        {
            Converter = new JsonByteConverter<string>();
            TestString = GetTestString();
        }
        
        [GlobalSetup(Target = nameof(MarshalByteConverterBenchmark))]
        public void Setup_MarshalByteConverter()
        {
            Converter = new MarshalByteConverter();
            TestString = GetTestString();
        }
        
        [GlobalSetup(Target = nameof(ProtoBufByteConverterBenchmark))]
        public void Setup_ProtoBufByteConverter()
        {
            Converter = new ProtoBufByteConverter<string>();
            TestString = GetTestString();
        }
                
        [GlobalSetup(Target = nameof(MessagePackByteConverterBenchmark))]
        public void Setup_MessagePackByteConverter()
        {
            Converter = new MessagePackByteConverter<string>();
            TestString = GetTestString();
        }
        
        [GlobalSetup(Target = nameof(UnicodeByteConverterBenchmark))]
        public void Setup_UnicodeByteConverter()
        {
            Converter = new UnicodeByteConverter();
            TestString = GetTestString();
        }
        
        [GlobalSetup(Target = nameof(Utf8ByteConverterBenchmark))]
        public void Setup_Utf8ByteConverter()
        {
            Converter = new Utf8ByteConverter();
            TestString = GetTestString();
        }

        [Benchmark(Baseline = true, Description = "BinaryFormatter")]
        public void BinaryFormatterByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
        
        [Benchmark(Description = "JSON")]
        public void JsonByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
        
        [Benchmark(Description = "Marshal")]
        public void MarshalByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
        
        [Benchmark(Description = "ProtoBuf")]
        public void ProtoBufByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
        
        [Benchmark(Description = "MessagePack")]
        public void MessagePackByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
        
        [Benchmark(Description = "Unicode")]
        public void UnicodeByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
        
        [Benchmark(Description = "UTF8")]
        public void Utf8ByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(TestString);
        }
    }
}