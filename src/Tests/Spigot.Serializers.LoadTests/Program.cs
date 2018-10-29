using BenchmarkDotNet.Running;

namespace Spigot.Serializers.LoadTests
{
    /*
    public class ResultingTimesColumn : IColumn
    {
        public string GetValue(Summary summary, Benchmark benchmark)
        {
            return string.Empty;
        }

        public bool IsDefault(Summary summary, Benchmark benchmark)
        {
            return true;
        }

        public bool IsAvailable(Summary summary)
        {
            return true;
        }

        public string Id { get; set; }
        public string ColumnName { get; set; }
        public bool AlwaysShow { get; set; }
        public ColumnCategory Category { get; set; } = ColumnCategory.Custom;
        public int PriorityInCategory { get; set; }
    }
    */

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SerializerLoadTests>();
        }
    }
}