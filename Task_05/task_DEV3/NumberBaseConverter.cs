using System;
using System.Text;
using System.Numerics;

namespace task_DEV3
{
    /// <summary>
    /// Provide a method for converts number's base
    /// </summary>
    public class NumberBaseConverter
    {
        /// <summary>
        /// The method converts number from decimal base to new base. 
        /// </summary>
        /// <param name="sourceNumber">A number which need to convert to other base.</param>
        /// <param name="newBase">New numeric system.</param>
        /// <returns>Number's presentation in new numeric system as string.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If new numeric system have illegal value( new base less then 2 or more than 20).</exception>
        /// <exception cref="ArgumentException">Source number must be positive</exception>
        public string GetNewNumberPresentation(BigInteger sourceNumber, int newBase)
        {
            ParametersValidation(sourceNumber, newBase);

            StringBuilder resultNumber = new StringBuilder();
            if (sourceNumber.IsZero)
            {
                return resultNumber.Append(0).ToString();
            }

            while (sourceNumber > 0)
            {
                int remainder = (int)(sourceNumber % newBase);
                if (remainder > 9)
                {
                    resultNumber.Insert(0, (char)(remainder + 'A' - 10));
                }
                else
                {
                    resultNumber.Insert(0, remainder);
                }
                sourceNumber /= newBase;
            }

            return resultNumber.ToString();
        }

        private void ParametersValidation(BigInteger sourceNumber, int newBase)
        {
            if (newBase < 2 || newBase > 20)
            {
                throw new ArgumentOutOfRangeException("newBase");
            }

            if (sourceNumber < 0)
            {
                throw new ArgumentException("Source number must be positive", "sourceNumber");
            }
        }
    }
}
