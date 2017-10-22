using System;
using System.Collections;
using System.Diagnostics;

namespace Homework
{
    /// <summary>
    /// Class contains methods working with numbers
    /// </summary>
    public static class Methods
    {
        /// <summary>
        /// Takes bits from <paramref name="secondNumber"/> and inserts them into <paramref name="firstNumber"/> to positions from <paramref name="startPosition"/> to <paramref name="endPosition"/>.
        /// </summary>
        /// <param name="firstNumber">32-bit number, which accepts insertion</param>
        /// <param name="secondNumber">32-bit number, which is being inserted</param>
        /// <param name="startPosition"><paramref name="firstNumber"/> position from which insertion starts</param>
        /// <param name="endPosition"><paramref name="firstNumber"/> position at which insertion ends</param>
        /// <returns>result of insertion</returns>
        public static int InsertNumber(int firstNumber, int secondNumber, byte startPosition, byte endPosition)
        {
            #region arguments validation
            if (endPosition > 31 || startPosition > 31)
            {
                throw new ArgumentOutOfRangeException("Maximum of bit position is 31.");
            }

            if (startPosition > endPosition)
            {
                throw new ArgumentException("Start position cannot be greater than end position.");
            }
            #endregion

            var firstNumberBits = new BitArray(new int[] { firstNumber });
            var secondNumberBits = new BitArray(new int[] { secondNumber });
            for (int index1 = startPosition, index2 = 0; index1 <= endPosition; index1++, index2++)
            {
                firstNumberBits.Set(index1, secondNumberBits.Get(index2));
            }
            var result = new int[1];
            firstNumberBits.CopyTo(result, 0);
            return result[0];
        }

        /// <summary>
        /// Finds the nearest number greater than <paramref name="number"/>, which consists of its digits.
        /// </summary>
        /// <param name="number">any positive integer number</param>
        /// <returns>the nearest number greater than <paramref name="number"/>, which consists of its digits or zero if there is no such number</returns>
        public static uint FindNextBiggerNumber(uint number)
        {
            #region arguments validation
            if (number == 0)
            {
                throw new ArgumentOutOfRangeException("Number must be positive.");
            }
            #endregion

            char[] numberChars = number.ToString().ToCharArray();
            int i = numberChars.Length - 1;
            while (i > 0)
            {
                if (numberChars[i] > numberChars[i - 1])
                {
                    char temp = numberChars[i];
                    numberChars[i] = numberChars[i - 1];
                    numberChars[i - 1] = temp;
                    char[] tail = new string(numberChars, i, numberChars.Length - i).ToCharArray();
                    Array.Sort(tail);

                    return uint.Parse(new string(numberChars, 0, i) + new string(tail));
                }
                i--;
            }

            return 0;
        }

        /// <summary>
        /// Finds the nearest number greater than <paramref name="number"/>, which consists of its digits and counts ticks during performance.
        /// </summary>
        /// <param name="number">any positive integer number</param>
        /// <param name="ticks">elapsed ticks</param>
        /// <returns>the nearest number greater than <paramref name="number"/>, which consists of its digits or zero if there is no such number</returns>
        public static uint FindNextBiggerNumber(uint number, out long ticks)
        {
            var sw = Stopwatch.StartNew();
            var result = FindNextBiggerNumber(number);
            sw.Stop();
            ticks = sw.ElapsedTicks;

            return result;
        }

        /// <summary>
        /// Filters list of <paramref name="numbers"/> on condition on containing specific <paramref name="digit"/>.
        /// </summary>
        /// <param name="digit">filtering digit</param>
        /// <param name="numbers">list of integers to filter</param>
        /// <returns>array of filtered numbers</returns>
        public static int[] FilterDigit(byte digit, params int[] numbers)
        {
            #region arguments validation
            if (digit > 9)
            {
                throw new ArgumentOutOfRangeException("digit", digit, "Parameter should be a digit.");
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException("No numbers to filter.");
            }
            #endregion

            var filtered = new System.Collections.Generic.List<int>();
            foreach (var number in numbers)
            {
                if (number.ToString().Contains(digit.ToString()))
                {
                    filtered.Add(number);
                }
            }

            return filtered.ToArray(); ;
        }

        /// <summary>
        /// Calculates square root with <paramref name="power"/> and specific <paramref name="precision"/> of <paramref name="number"/> using Newton's method.
        /// </summary>
        /// <param name="number">number to calculate its square root</param>
        /// <param name="power">square root power</param>
        /// <param name="precision">calculative precision</param>
        /// <returns></returns>
        public static double FindNthRoot(double number, byte power, double precision)
        {
            #region arguments validation
            if (power == 0)
            {
                throw new ArgumentOutOfRangeException("sqrtpow", power, "Square root power must be a natural number.");
            }

            if (number < 0 && power % 2 == 0)
            {
                throw new ArgumentException("Cannot calculate square root with even power of negative numbers.");
            }

            if (precision <= 0 || precision > 1)
            {
                throw new ArgumentOutOfRangeException("precision", precision, "Precision can only have values greater than 0 and less than or equal to 1.");
            }
            #endregion

            if (number == 0)
            {
                return 0;
            }

            double x; // previous iterated x
            double xi = number / precision; // iterative x
            do
            {
                x = xi;
                xi = 1d / power * ((power - 1) * xi + number / Math.Pow(xi, power - 1));
            } while (Math.Abs(xi - x) > precision);

            return Math.Round(xi, -(int)Math.Log10(precision));
        }
    }
}
