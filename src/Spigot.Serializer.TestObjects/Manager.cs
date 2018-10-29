using System.Collections.Generic;
using System.Linq;
using ProtoBuf;

namespace Spigot.Serializer.TestObjects
{
    [ProtoContract]
    public class Manager : Employee
    {
        [ProtoMember(1)]
        public string Department { get; set; }

        [ProtoMember(2)]
        public List<Employee> Employees { get; set; }

        public override bool Equals(object obj)
        {
            var manager = obj as Manager;
            var employeeComparer = new MultiSetComparer<Employee>();
            return manager != null &&
                   base.Equals(obj) &&
                   Department == manager.Department &&
                   employeeComparer.Equals(Employees, manager.Employees);
        }

        public override int GetHashCode()
        {
            var hashCode = 2073372219;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Department);
            hashCode = hashCode * -1521134295 + Employees.Sum(e => e.GetHashCode());
            return hashCode;
        }
    }
}