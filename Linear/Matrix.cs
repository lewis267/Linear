using System;
using System.Diagnostics;
using System.Text;

namespace Linear
{
    public class Matrix<T>
    {
        private T[,] matrix;

        public Matrix(int n, int m)
        {
            matrix = new T[n,m];
        }

        public int N
        {
            get { return matrix.GetLength(0); }
        }
        public int M
        {
            get { return matrix.GetLength(1); }
        }

        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            Debug.Assert(a.N == b.N && a.M == b.M);

            Matrix<T> m = new Matrix<T>(a.N, a.M);

            for (int i = 0; i < a.N; i++)
            {
                for (int j =0; j < a.M; j++)
                {
                    dynamic c = a[i, j];
                    dynamic d = b[i, j];

                    m[i, j] = c + d;
                }
            }

            return m;
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            Debug.Assert(a.M == b.N);
            Matrix<T> m = new Matrix<T>(a.N, b.M);

            for (int ra = 0; ra < a.N; ra++)
            {
                for (int cb = 0; cb < b.M; cb++)
                {
                    dynamic tot = 0;
                    dynamic av = a[ra, 0];
                    dynamic bv = b[0, cb];
                    tot = av * bv;

                    for (int i = 1; i < a.M; i++)
                    {
                        av = a[ra, i];
                        bv = b[i, cb];
                        tot += av * bv;
                    }

                    m[ra, cb] = tot;
                }
            }

            return m;
        }
        public static Matrix<T> operator *(T n, Matrix<T> a)
        {
            Matrix<T> m = new Matrix<T>(a.N, a.M);

            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.M; j++)
                {
                    dynamic c = a[i, j];

                    m[i, j] = c*n;
                }
            }

            return m;
        }

        public static bool operator ==(Matrix<T> a, Matrix<T> b)
        {
            if (a.N != b.N || a.M != b.M) return false;

            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < a.M; j++)
                {
                    if (!Equals(a[i, j], b[i, j])) return false;
                }
            }

            return true;
        }
        public static bool operator !=(Matrix<T> a, Matrix<T> b)
        {
            return !(a == b);
        }

        public T this[int i, int j]
        {
            get { return matrix[i,j]; }
            set { matrix[i,j] = value; }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    b.Append(" " + this[i, j].ToString());
                }
                b.Append(Environment.NewLine);
            }
            return b.ToString();
        }

        // Adjoint (transpose)
        public static Matrix<T> Adjoint(Matrix<T> m)
        {
            Matrix<T> n = new Matrix<T>(m.N, m.M);

            for (int i= 0; i < m.N; i++)
            {
                for (int j = 0; j < m.M; j++)
                {
                    n[j, i] = m[i, j];
                }
            }

            return n;
        }

        // Normal Check
        public bool isNormal(Matrix<T> m)
        {
            return Adjoint(m) * m == m * Adjoint(m);
        }

        #region --- Matrix Reduction ---

        public Matrix<T> EF(Matrix<T> m, bool print = false)
        {
            throw new NotImplementedException();
        }

        public Matrix<T> RREF(Matrix<T> a, bool print = false)
        {
            var m = EF(a);
            throw new NotImplementedException();
        }

        #endregion
    }
}
