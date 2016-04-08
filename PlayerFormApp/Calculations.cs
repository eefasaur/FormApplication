using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerFormApp
{
    class Calculations
    {
        public double calculateMax(List<double> numbers)
        {
            int n = numbers.Count - 1;
            numbers.Sort();
            return numbers[n];
        }

        public double calculateMin(List<double> numbers)
        {
            numbers.Sort();
            return numbers[0];

        }

        public double calculateMean(List<double> numbers)
        {
            double total = numbers.Sum();
            int n = numbers.Count();
            return total / n;

        }
    }
}
