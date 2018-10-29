using System.Collections.Generic;
using Archetypical.Software.Spigot;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Spigot.Serializer.Tests;

namespace Spigot.Serializers.LoadTests
{
    [ClrJob]
    [RankColumn, AllStatisticsColumn, GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
    [HtmlExporter, MarkdownExporter]
    public class SerializerLoadTests
    {
        [Params(5, 25, 50, 100)]
        public int N { get; set; }

        private Manager CreateManager(int numberOfEmployees)
        {
            var expected = new Manager()
            {
                Name = "Mr. Big Shot",
                Id = 0,
                Department = "Development",
                Employees = new List<Employee>()
            };
            for (int i = 0; i < numberOfEmployees; i++)
            {
                expected.Employees.Add(CreateEmployee(expected, i));
            }
            return expected;
        }

        private Employee CreateEmployee(Manager manager, int index)
        {
            return new Employee
            {
                Name = $"Employee number {index}",
                Id = index,
                Manager = manager
            };
        }

        private Manager dataToSerialze;

        private ISpigotSerializer _jsonSerializer;
        private ISpigotSerializer _protoSerializer;
        private ISpigotSerializer _msgPackSerializer;

        [GlobalSetup]
        public void Setup()
        {
            dataToSerialze = CreateManager(N);
            _jsonSerializer = new Archetypical.Software.Spigot.Serializers.Json.SpigotSerializer();
            _protoSerializer = new Archetypical.Software.Spigot.Serializers.Protobuf.SpigotSerializer();
            _msgPackSerializer = new Archetypical.Software.Spigot.Serializers.MsgPack.SpigotSerializer();
        }

        [Benchmark]
        public byte[] JsonSerializer() => _jsonSerializer.Serialize(dataToSerialze);

        [Benchmark]
        public byte[] ProtoBufSerializer() => _protoSerializer.Serialize(dataToSerialze);

        [Benchmark]
        public byte[] MsgPackSerializer() => _msgPackSerializer.Serialize(dataToSerialze);
    }
}