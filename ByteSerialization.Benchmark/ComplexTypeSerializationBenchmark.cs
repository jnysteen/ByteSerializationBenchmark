using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Order;
using MessagePack;
using Newtonsoft.Json;
using ProtoBuf;

namespace ByteSerialization.Benchmark
{
    /// <summary>
    /// Benchmarks the implementations' performances when serializing complex types
    /// </summary>
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [EncodingAttribute.Unicode]
    [CsvExporter(CsvSeparator.Semicolon), RPlotExporter]
    public class ComplexTypeSerializationBenchmark
    {
        /// <summary>
        /// The converter used in each benchmark
        /// </summary>
        public IByteConverter<ComplexType> Converter { get; set; }
        
        /// <summary>
        /// The actual input to the serializer implementations
        /// </summary>
        public ComplexType Input { get; set; }
        
        /// <summary>
        /// The number of children contained in every complex type instance
        /// </summary>
        public int ChildrenPerInstance = 3;
        
        /// <summary>
        /// The depth of the object graph generated for the root complex type instance 
        /// </summary>
        public int Depth = 3;

        /// <summary>
        /// Produces the test input
        /// </summary>
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

        [Benchmark(Baseline = true, Description = "BinaryFormatter")]
        public void BinaryFormatterByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(Input);
        }
        
        
        [GlobalSetup(Target = nameof(JsonByteConverterBenchmark))]
        public void Setup_JsonByteConverter()
        {
            Converter = new JsonByteConverter<ComplexType>();
            Input = CreateComplexType();
        }

        [Benchmark(Description = "JSON")]
        public void JsonByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(Input);
        }
        
        
        [GlobalSetup(Target = nameof(ProtoBufByteConverterBenchmark))]
        public void Setup_ProtoBufByteConverter()
        {
            Converter = new ProtoBufByteConverter<ComplexType>();
            Input = CreateComplexType();
        }

        [Benchmark(Description = "ProtoBuf")]
        public void ProtoBufByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(Input);
        }
        
        
        [GlobalSetup(Target = nameof(MessagePackByteConverterBenchmark))]
        public void Setup_ZeroFormatterByteConverter()
        {
            Converter = new MessagePackByteConverter<ComplexType>();
            Input = CreateComplexType();
        }
        
        [Benchmark(Description = "MessagePack")]
        public void MessagePackByteConverterBenchmark()
        {
            var bytes = Converter.GetBytes(Input);
        }
    }

    [MessagePackObject] // MessagePack requires this
    [Serializable] // The BinaryFormatter requires this
    [ProtoContract] // ProtoBuf requires this
    public class ComplexType
    {
        [Key(0)] // MessagePack requires this
        [DataMember] // The BinaryFormatter *might* require this 
        [JsonProperty]  // The JSON converter *might* require this
        [ProtoMember(1)] // ProtoBuf requires this
        public int Id { get; set; } // MessagePack requires the getter and setter to be public 

        [Key(1)] // MessagePack requires this
        [DataMember] // The BinaryFormatter *might* require this 
        [JsonProperty]  // The JSON converter *might* require this
        [ProtoMember(2)] // ProtoBuf requires this
        public IList<ComplexType> Children { get; set; }

        public static ComplexType Create(int childrenPerInstance, int depth)
        {
            var idSupplier = new IdSupplier();
            return Create(idSupplier, childrenPerInstance, depth);
        }
        
        private static ComplexType Create(IdSupplier idSupplier,int childrenPerInstance, int depth)
        {
            var instance = new ComplexType()
            {
                Id = idSupplier.GetId(),
                Children = new List<ComplexType>()
            };

            if (depth == 0)
                return instance;

            for (int i = 0; i < childrenPerInstance; i++)
                instance.Children.Add(Create(idSupplier, childrenPerInstance, depth - 1));
            
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