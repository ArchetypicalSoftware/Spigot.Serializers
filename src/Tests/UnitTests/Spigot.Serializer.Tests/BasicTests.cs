using Archetypical.Software.Spigot;
using System.Collections.Generic;
using Spigot.Serializer.TestObjects;
using Xunit;

namespace Spigot.Serializer.Tests
{
    public class BasicTests
    {
        [Fact]
        public void Json_Serializer_Basic_Test()
        {
            var serializer = new Archetypical.Software.Spigot.Serializers.Json.SpigotSerializer();
            Test_Serializer(serializer);
        }

        [Fact]
        public void MsgPack_Serializer_Basic_Test()
        {
            var serializer = new Archetypical.Software.Spigot.Serializers.MsgPack.SpigotSerializer();
            Test_Serializer(serializer);
        }

        [Fact]
        public void Protobuf_Serializer_Basic_Test()
        {
            var serializer = new Archetypical.Software.Spigot.Serializers.Protobuf.SpigotSerializer();
            Test_Serializer(serializer);
        }

        private void Test_Serializer(ISpigotSerializer serializer)
        {
            var expected = new Manager()
            {
                Name = "John Doe",
                Id = 1,
                Department = "Development",
                Employees = new List<Employee>()
            };
            expected.Employees.Add(new Employee
            {
                Name = "Jane Doe",
                Id = 2,
                Manager = expected
            });
            Assert.Equal(expected, expected);
            var bites = serializer.Serialize(expected);

            var actual = serializer.Deserialize<Manager>(bites);

            Assert.StrictEqual(expected, actual);
        }
    }
}