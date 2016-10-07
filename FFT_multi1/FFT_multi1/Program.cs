using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace FFT_multi1
{
    class Program
    {
        private static readonly int np = 3;
        private static readonly int n = 1 << np;
        private static readonly Complex omega = new Complex(Math.Cos(-2 * Math.PI / n), Math.Sin(-2 * Math.PI / n));

        Complex[] fft(double[] x)
        {
            Complex[] y = new Complex[n];

            for (int i = 0; i < n; i++)
            {
            }

            return y;
        }

        static void Main(string[] args)
        {
            double[] a = { 93.0, 97.0, 58.0, 53.0, 26.0, 59.0, 41.0, 31.0 },
                     b = { 95.0, 27.0, 83.0, 33.0, 64.0, 62.0, 84.0, 23.0 };
            Complex[] fft_a, fft_b;



        }
    }
}
