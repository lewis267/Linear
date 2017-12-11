using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Linear
{
    public class Vector<T>
    {
        T[] vector;

        public Vector(int dimension)
        {
            vector = new T[dimension];
        }

        public Vector(Vector<T> v)
        {
            vector = new T[v.Dimention];
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = v[i];
            }
        }

        public Vector(IList<T> l)
        {
            vector = new T[l.Count];
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = l[i];
            }
        }

        public T this[int i]
        {
            get { return vector[i]; }
            set { vector[i] = value; }
        }

        public int Dimention
        {
            get { return vector.Length; }
        }

        public static Vector<T> operator +(Vector<T> a, Vector<T> b)
        {
            Debug.Assert(a.Dimention == b.Dimention);

            var v = new Vector<T>(a.Dimention);
            for (int i = 0; i < a.Dimention; i++)
            {
                dynamic c = a[i];
                dynamic d = b[i];

                v[i] = c + d;
            }
            return v;
        }

        public static Vector<T> operator -(Vector<T> a, Vector<T> b)
        {
            dynamic no = -1;
            return a + ((T)no * b);
        }

        public static Vector<T> operator *(T c, Vector<T> v)
        {
            Vector<T> w = new Vector<T>(v.Dimention);
            for (int i = 0; i < v.Dimention; i++)
            {
                dynamic a = c;
                dynamic b = v[i];

                w[i] = a * b;
            }
            return w;
        }

        public static T InnerProduct(Vector<T> a, Vector<T> b)
        {
            Debug.Assert(a.Dimention == b.Dimention);

            dynamic t = 0;
            for (int i = 0; i < a.Dimention; i++)
            {
                dynamic c = a[i];
                dynamic d = b[i];

                t += c * d;
            }

            return (T)t;
        }

        public static T Norm(Vector<T> a)
        {
            dynamic v = InnerProduct(a, a);
            dynamic sq = System.Math.Sqrt((double)v);
            return (T)sq;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("(");
            for (int i = 0; i < Dimention; i++)
            {
                sb.Append(" " + this[i].ToString());
            }
            sb.Append(")");
            return sb.ToString();
        }
    }
}
