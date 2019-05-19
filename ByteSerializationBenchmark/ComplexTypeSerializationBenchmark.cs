using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using ByteSerialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProtoBuf;

namespace ByteSerializationBenchmark
{
    [CoreJob()]
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [EncodingAttribute.Unicode]
    [CsvExporter(CsvSeparator.Semicolon), RPlotExporter]
    public class ComplexTypeSerializationBenchmark
    {
        public IByteConverter<ComplexType> Converter { get; set; }
        public ComplexType Input { get; set; }
        
        public int ChildrenPerInstance = 3;
        public int Depth = 3;

        private ComplexType CreateComplexType()
        {
            return ComplexType.Create(ChildrenPerInstance, Depth);
        }

        [GlobalSetup(Target = nameof(BinaryFormatterByteConverterBenchmark))]
        public void Setup_BinaryFormatterByteConverter()
        {
            Converter = new BinaryFormatterByteConverter<ComplexType>();
            Input = CreateComplexType();
        }

        [GlobalSetup(Target = nameof(JsonByteConverterBenchmark))]
        public void Setup_JsonByteConverter()
        {
            Converter = new JsonByteConverter<ComplexType>();
            Input = CreateComplexType();
        }

        [GlobalSetup(Target = nameof(ProtoBufByteConverterBenchmark))]
        public void Setup_ProtoBufByteConverter()
        {
            Converter = new ProtoBufByteConverter<ComplexType>();
            Input = CreateComplexType();
        }

        [Benchmark(Baseline = true, Description = "BinaryFormatter")]
        public void BinaryFormatterByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(Input);
        }

        [Benchmark(Description = "JSON")]
        public void JsonByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(Input);
        }

        [Benchmark(Description = "ProtoBuf")]
        public void ProtoBufByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(Input);
        }
    }

    [Serializable] // The BinaryFormatter requires this when serializing
    [ProtoContract] // ProtoBuf requires this when serializing
    public class ComplexType
    {
        [DataMember] // The BinaryFormatter *might* require this 
        [JsonProperty]  // The JSON converter *might* require this
        [ProtoMember(1)] // ProtoBuf requires this when serializing
        public int Id { get; private set; }

        [DataMember] // The BinaryFormatter *might* require this 
        [JsonProperty]  // The JSON converter *might* require this
        [ProtoMember(2)] // ProtoBuf requires this when serializing
        public List<ComplexType> Children { get; set; }

        public static ComplexType Create(int childrenPerInstance, int depth)
        {
            var idSupplier = new IdSupplier();
            var instance = new ComplexType()
            {
                Id = idSupplier.GetId()
            };

            if (depth == 0)
                return instance;
            
            instance.Children = Enumerable.Repeat(Create(idSupplier, childrenPerInstance, depth - 1), childrenPerInstance).ToList();
            return instance;
        }
        
        private static ComplexType Create(IdSupplier idSupplier,int childrenPerInstance, int depth)
        {
            var instance = new ComplexType()
            {
                Id = idSupplier.GetId()
            };

            if (depth == 0)
                return instance;
            
            instance.Children = Enumerable.Repeat(Create(idSupplier, childrenPerInstance, depth - 1), childrenPerInstance).ToList();
            return instance;
        }

        public IEnumerable<ComplexType> BreadthFirstEnumeration()
        {
            var queue = new Queue<ComplexType>();
            queue.Enqueue(this);
            while (queue.Any())
            {
                var c = queue.Dequeue();
                yield return c;
                if (c.Children == null) 
                    continue;
                foreach (var child in c.Children)
                    queue.Enqueue(child);
            }
        }

        public override string ToString()
        {
            return $"Id: {Id}";
        }

        private class IdSupplier
        {
            private int _nextId = 1;

            public int GetId()
            {
                return _nextId++;
            }
        }
        
    }
    
    
}