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
        private static Complex[] omega;

        public Program()
        {
            omega = new Complex[n];

            for(int i=0; i < n; i++)
            {
                omega[i] = new Complex(Math.Cos(-2 * Math.PI / n * i), Math.Sin(-2 * Math.PI / n * i));
            }

        }


        static void dft(ref double[] x, ref Complex[] y)
        {
            for (int i = 0; i < n; i++)
            {
                var t = new Complex(0, 0);

                for (int j = 0; j < n; j++)
                {
                    t += new Complex(x[j], 0) * omega[i * j % n];
                }

                y[i] = t;
            }
        }

        static void Main(string[] args)
        {
            double[] a = { 93.0, 97.0, 58.0, 53.0, 26.0, 59.0, 41.0, 31.0 },
                     b = { 95.0, 27.0, 83.0, 33.0, 64.0, 62.0, 84.0, 23.0 };
            var dft_a = new Complex[n];
            var dft_b = new Complex[n];

            dft(ref a, ref dft_a);
            dft(ref b, ref dft_b);

        }
    }
}
