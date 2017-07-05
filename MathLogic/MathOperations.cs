using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLogic
{
    public static class MathOperations
    {
        /// <summary>
        /// implements Newton algorythm for getting any natural power root from number
        /// </summary>
        /// <param name="number">number</param>
        /// <param name="power">natural power of root</param>
        /// <param name="accuracy">minimum accuracy</param>
        /// <returns>root value (value^power=number)</returns>
        /// <exception cref="ArgumentOutOfRangeException">using negative number,power or accuracy</exception>
        public static double SqrtNewton(double number, int power = 2 , double accuracy = 0)
        {
            if (number < 0) throw new ArgumentOutOfRangeException($"{nameof(number)} value must be > 0");
            if (power < 0) throw new ArgumentOutOfRangeException($"{nameof(power)} value must be natural");
            if (accuracy < 0) throw new ArgumentOutOfRangeException($"{nameof(accuracy)} value must be > 0");

            double x = number, delta = x;

            while (delta > accuracy)
            {
                var prevx = x;
                x = (1.0 / (double)power) * ((power - 1) * x + number / Math.Pow(x, power - 1));
                delta = Math.Abs(prevx - x);
            }

            return x;
        }
    }
}
