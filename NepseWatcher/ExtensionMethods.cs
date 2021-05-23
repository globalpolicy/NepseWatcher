using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NepseWatcher
{
    public static class ExtensionMethods
    {
        public static T GetLast<T>(this List<T> list)
        {
            return list[list.Count - 1];
        }

        public static T GetSecLast<T>(this List<T> list)
        {
            return list[list.Count - 2];
        }

        public static T GetThirdLast<T>(this List<T> list)
        {
            return list[list.Count - 3];
        }

        /// <summary>
        /// Calculates weighted average of the given list of floats biased towards the more recent(latter) data.
        /// </summary>
        /// <param name="list">The list of floats</param>
        /// <param name="type">0 for linear weights, 1 for logarithmic weights</param>
        /// <returns></returns>
        public static float WeightedAverage(this List<float> list, int type)
        {
            //populate weights
            List<float> weights = new List<float>();
            for (int i = 0; i < list.Count; i++)
            {
                switch (type)
                {
                    case 0:
                        weights.Add((float)(i + 1));
                        break;
                    case 1:
                        weights.Add((float)Math.Log(i + 1));
                        break;
                    default:
                        weights.Add((float)(i + 1));
                        break;
                }
            }
            float sumOfWeights = weights.Sum();

            //sum up weighted elements
            float sum = 0;
            for (int i = 0; i < list.Count; i++)
                sum += list[i] * weights[i];
            
            return sum / sumOfWeights;

        }
    }
}
