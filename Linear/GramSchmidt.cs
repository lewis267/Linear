using System.Collections.Generic;

namespace Linear
{
    public class GramSchmidt<F>
    {
        public static List<Vector<F>> Orthogonalize(IList<Vector<F>> vectors)
        {
            var U = new List<Vector<F>>();

            U.Add(vectors[0]);

            for (int k = 1; k < vectors.Count; k++)
            {
                Vector<F> sum = new Vector<F>(U[0].Dimention);

                foreach (Vector<F> ui in U)
                {
                    dynamic top = Vector<F>.InnerProduct(vectors[k], ui);
                    dynamic bottom = Vector<F>.InnerProduct(ui, ui);

                    sum += (top / bottom) * ui;
                }

                U.Add(vectors[k] - sum);
            }

            return U;
        }

        public static List<Vector<F>> Normalize(IList<Vector<F>> vectors)
        {
            var U = new List<Vector<F>>();

            for (int i = 0; i < vectors.Count; i++)
            {
                dynamic factor = Vector<F>.Norm(vectors[i]);

                U.Add(((F)(1/factor)) * vectors[i]);
            }

            return U;
        }
    }
}
