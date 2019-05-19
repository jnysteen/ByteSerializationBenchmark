using System;
using System.Collections;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using ByteSerialization;
using CommandLine;

namespace ByteSerializationBenchmark
{
    [CoreJob()]
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [EncodingAttribute.Unicode]
    [CsvExporter(CsvSeparator.Semicolon), RPlotExporter]
    public class StringByteSerializationBenchmarker
    {
        [Params(32)]
        public int StringLength { get; set; }
        public IByteConverter<string> Converter { get; set; }
        public string TestString { get; set; }
        
        public StringByteSerializationBenchmarker()
        {
            TestString = string.Join("", Enumerable.Repeat("a", StringLength));
        }

        [GlobalSetup(Target = nameof(BinaryFormatterByteConverterBenchmark))]
        public void Setup_BinaryFormatterByteConverter()
        {
            Converter = new BinaryFormatterByteConverter<string>();
        }
        
        [GlobalSetup(Target = nameof(JsonByteConverterBenchmark))]
        public void Setup_JsonByteConverter()
        {
            Converter = new JsonByteConverter<string>();
        }
        
        [GlobalSetup(Target = nameof(MarshalByteConverterBenchmark))]
        public void Setup_MarshalByteConverter()
        {
            Converter = new MarshalByteConverter();
        }
        
        [GlobalSetup(Target = nameof(ProtoBufByteConverterBenchmark))]
        public void Setup_ProtoBufByteConverter()
        {
            Converter = new ProtoBufByteConverter<string>();
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
    }
}