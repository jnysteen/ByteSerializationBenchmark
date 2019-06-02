using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using ByteSerialization;
using ByteSerialization.Benchmark;
using ByteSerialization.StringOnly;
using Xunit;
using Xunit.Abstractions;

namespace ByteSerializationBenchmark.Tests
{
    public class ByteSerializationTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ByteSerializationTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        public static IEnumerable<object[]> StringConverters
        {
            get
            {
                yield return new object[] {new JsonByteConverter<string>()};
                yield return new object[] {new BinaryFormatterByteConverter<string>()};
                yield return new object[] {new MarshalByteConverter()};
                yield return new object[] {new UnicodeByteConverter()};
                yield return new object[] {new Utf8ByteConverter()};
                yield return new object[] {new ProtoBufByteConverter<string>()};
                yield return new object[] {new MessagePackByteConverter<string>()};
            }
        }

        public static IEnumerable<object[]> ComplexTypeConverters
        {
            get
            {
                yield return new object[] {new JsonByteConverter<ComplexType>()};
                yield return new object[] {new BinaryFormatterByteConverter<ComplexType>()};
                yield return new object[] {new ProtoBufByteConverter<ComplexType>()};
                yield return new object[] {new MessagePackByteConverter<ComplexType>()};
            }
        }

        [Theory]
        [MemberData(nameof(StringConverters))]
        public void SerializationWorks_Strings(IByteConverter<string> byteConverter)
        {
            const string s = "test-string";
            var serialized = byteConverter.GetBytes(s);
            var deserialized = byteConverter.GetObject(serialized);
            Assert.Equal(s, deserialized);
        }

        [Theory]
        [MemberData(nameof(ComplexTypeConverters))]
        public void SerializationWorks_ComplexType(IByteConverter<ComplexType> byteConverter)
        {
            var complexType = ComplexType.Create(3, 3);
            var serialized = byteConverter.GetBytes(complexType);
            var deserialized = byteConverter.GetObject(serialized);

            var expected = complexType.BreadthFirstEnumeration().ToArray();
            var actual = deserialized.BreadthFirstEnumeration().ToArray();

            for (var i = 0; i < expected.Length; i++)
            {
                var e = expected[i];
                var a = actual[i];
                Assert.Equal(e.Id, a.Id);
            }
        }
    }
}