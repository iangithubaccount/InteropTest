using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;

namespace InteropTest
{
    public partial class MainWindow : Window
    {
        [DllImport("DLL path")]
        static extern uint NthPrimeNumber(uint n);
        public MainWindow()
        {
            InitializeComponent();
        }

        private uint[] Benchmark(Func<uint, uint> methodName, uint args)
        {
            uint[] returnData = new uint[2];
            Stopwatch perf = new Stopwatch();
            perf.Start();
            returnData[0] = methodName(args);
            perf.Stop();
            returnData[1] = (uint)perf.ElapsedMilliseconds;
            return returnData;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            uint input = uint.Parse(InputField.Text);
            if (input > 10000)
            {
                MessageBox.Show("Number too big");
                return;
            }

            uint[] CppResult = Benchmark(NthPrimeNumber, input);
            CppRuntimeLabel.Content = $"C++ Runtime (MS): {CppResult[1]}";
            uint[] CsResult = Benchmark(NthPrime, input);
            CsRuntimeLabel.Content = $"C# Runtime (MS): {CsResult[1]}";

            OutputLabel.Content = $"Output: {CppResult[0]}";
        }

        uint NthPrime(uint n)
        {
            uint i = 1;
            bool isPrime = true;
            uint primeCount = 0;
            while (true)
            {
                isPrime = true;
                for (uint factor = 3; factor < i; factor += 2)
                {
                    if (i % factor == 0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime)
                {
                    if (primeCount == n - 1)
                    {
                        return i;
                    }
                    primeCount++;
                }
                i += 2;
            }
        }
    }
}
