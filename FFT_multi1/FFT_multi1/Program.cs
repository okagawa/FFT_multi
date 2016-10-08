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
        private static Complex[] omega = new Complex[n];
        private static Complex[] iomega = new Complex[n];


        static void dft(ref double[] x, ref Complex[] y)
        {
            for (int i = 0; i < n; i++)
            {
                var t = new Complex(0, 0);

                for (int j = 0; j < n; j++)
                {
                    t += new Complex(x[j], 0) * omega[(i * j) % n];
                }

                y[i] = t;
            }
        }

        static void idft(ref Complex[] x, ref double[] y)
        {
            for (int i = 0; i < n; i++)
            {
                var t = new Complex(0, 0);

                for (int j = 0; j < n; j++)
                {
                    t += x[j] * iomega[( i * j) % n];
                }
                y[i] = t.Real / n;
            }
        }

        static void mult(ref Complex[] x, ref Complex[] y, ref Complex[] z)
        {
            for (int i=0; i< n; i++)
            {
                z[i] = x[i] * y[i];
            }
        }

        static void Main(string[] args)
        {
//            double[] a = { 93.0, 97.0, 58.0, 53.0, 26.0, 59.0, 41.0, 31.0 },
//                     b = { 95.0, 27.0, 83.0, 33.0, 64.0, 62.0, 84.0, 23.0 },
            double[] a = { 93.0, 97.0, 58.0, 53.0, 0, 0, 0, 0 },
                     b = { 95.0, 27.0, 83.0, 33.0, 0, 0, 0, 0 },
                     c = new double[n];
            var dft_a = new Complex[n];
            var dft_b = new Complex[n];
            var dft_c = new Complex[n];

            for (int i = 0; i < n; i++)
            {
                omega[i] = new Complex(Math.Cos(-2 * Math.PI / n * i), Math.Sin(-2 * Math.PI / n * i));
                iomega[i] = new Complex(Math.Cos(2 * Math.PI / n * i), Math.Sin(2 * Math.PI / n * i));
            }

            dft(ref a, ref dft_a);
            dft(ref b, ref dft_b);

            mult(ref dft_a, ref dft_b, ref dft_c);

            idft(ref dft_c, ref c);

            for(int i=0; i< n; i++)
            {
                Console.WriteLine("{0}", c[i]);
            }
            Console.ReadKey();
        }
    }
}
