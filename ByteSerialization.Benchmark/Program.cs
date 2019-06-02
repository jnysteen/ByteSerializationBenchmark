using System.Globalization;
using System.Threading;
using BenchmarkDotNet.Running;

namespace ByteSerialization.Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Without the line below, parameters with decimals will be outputted with commas in certain cultures
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}