using ProtoBuf;
using System.Collections.Generic;

namespace Spigot.Serializer.Tests
{
    [ProtoContract]
    [ProtoInclude(4, typeof(Manager))]
    public class Employee
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3, AsReference = true, IsRequired = false)]
        public Manager Manager { get; set; }

        public override bool Equals(object obj)
        {
            var employee = obj as Employee;
            return employee != null &&
                   Id == employee.Id &&
                   Manager?.Id == employee.Manager?.Id &&
                   Name == employee.Name;
        }

        public override int GetHashCode()
        {
            var hashCode = 2144479570;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}