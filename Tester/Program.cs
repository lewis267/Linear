using System;
using Linear;
using System.Collections.Generic;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> m = new Matrix<int>(2, 2);
            m[0, 0] = 2;
            m[1, 1] = 2;
            m[0, 1] = 12;

            Console.WriteLine(m[0, 0]);
            Console.ReadKey();

            Matrix<int> m2 = new Matrix<int>(2, 2);
            m2[0, 0] = 1;
            m2[1, 1] = 2;

            var m3 = m * m2;

            Console.WriteLine("a = \r\n" + m);
            Console.WriteLine("b = \r\n" + m2);

            Console.WriteLine("a * b = \r\n" + m3);

            Console.WriteLine();
            Console.WriteLine(Matrix<int>.Adjoint(m).ToString());

            Console.ReadKey();

            var v1 = new Vector<double>(new List<double> { 1, 1, 1 });
            var v2 = new Vector<double>(new List<double> { 1, 2, 1 });
            var v3 = new Vector<double>(new List<double> { -4, 3, 1 });

            Console.WriteLine("v1: " + v1.ToString());
            Console.WriteLine("v2: " + v2.ToString());
            Console.WriteLine("v3: " + v3.ToString());

            var vects = new List<Vector<double>> { v1, v2, v3 };
            var orthoVects = GramSchmidt<double>.Orthogonalize(vects);
            var orthoNormVects = GramSchmidt<double>.Normalize(orthoVects);

            foreach (var v in orthoNormVects)
            {
                Console.WriteLine(v);
            }

            Console.ReadKey();
        }
    }
}
