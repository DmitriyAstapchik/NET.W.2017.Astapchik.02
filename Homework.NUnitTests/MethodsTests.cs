using System;
using NUnit.Framework;
using static Homework.Methods;

namespace Homework.NUnit.Tests
{
    [TestFixture]
    public class MethodsTests
    {
        #region InsertNumber tests
        [TestCase(56, 56, 3, 5, ExpectedResult = 0)]
        [TestCase(127, 8, 2, 4, ExpectedResult = 99)]
        [TestCase(9689, 777, 0, 20, ExpectedResult = 777)]
        [TestCase(135, 502, 0, 31, ExpectedResult = 502)]
        [TestCase(25, 52, 10, 20, ExpectedResult = 53273)]
        [TestCase(int.MinValue, int.MaxValue, 0, 30, ExpectedResult = -1)]
        [TestCase(-2130129, -99, 0, 31, ExpectedResult = -99)]
        public int InsertNumberTestResult(int first, int second, byte start, byte end)
        {
            return InsertNumber(first,  second, start, end);
        }

        [TestCase(1111, 3, 31, 31)]
        [TestCase(123456, 127, 26, 31)]
        public void InsertNumberTestAssertLess(int first, int second, byte start, byte end)
        {
            var result = InsertNumber(first,  second, start, end);
            Assert.Less(result, 0);
        }


        [TestCase(-1239525, 9847, 15, 31)]
        [TestCase(156463, -798427, 2, 22)]
        public void InsertNumberTestAssertGreater(int first, int second, byte start, byte end)
        {
            var result = InsertNumber(first,  second, start, end);
            Assert.Greater(result, 0);
        }

        [TestCase(22, 222, 22, 222)]
        [TestCase(-34144, 23032, 133, 135)]
        public void InsertNumberTestArgumentOutOfRangeException(int first, int second, byte i, byte j)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumber(first, second, i, j));
        }
        #endregion

        #region FindNextBiggerNumber tests
        [TestCase(5u, ExpectedResult = 0)]
        [TestCase(12u, ExpectedResult = 21)]
        [TestCase(513u, ExpectedResult = 531)]
        [TestCase(2017u, ExpectedResult = 2071)]
        [TestCase(414u, ExpectedResult = 441)]
        [TestCase(144u, ExpectedResult = 414)]
        [TestCase(1234321u, ExpectedResult = 1241233)]
        [TestCase(1234126u, ExpectedResult = 1234162)]
        [TestCase(3456432u, ExpectedResult = 3462345)]
        [TestCase(10u, ExpectedResult = 0)]
        [TestCase(200u, ExpectedResult = 0)]
        [TestCase(9876662u, ExpectedResult = 0)]
        [TestCase(443322110u, ExpectedResult = 0)]
        [TestCase(537744220u, ExpectedResult = 570223447)]
        [TestCase(2809296711u, ExpectedResult = 2809297116)]
        public uint FindNextBiggerNumberTestResult(uint number)
        {
            return FindNextBiggerNumber(number);
        }

        [TestCase(0u)]
        public void FindNextBiggerNumberTestArgumentOutOfRangeException(uint number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => FindNextBiggerNumber(number));
        }

        [TestCase(23u)]
        [TestCase(758142u)]
        [TestCase(1290104274u)]
        public void FindNextBiggerNumberTestStopwatch(uint number)
        {
            FindNextBiggerNumber(number, out long ticks);
            Assert.True(ticks > 1);
        }
        #endregion

        #region FilterDigit tests
        [TestCase(7, 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17, ExpectedResult = new int[] { 7, 70, 17 })]
        [TestCase(7, new int[] { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, ExpectedResult = new int[] { 7, 70, 17 })]
        [TestCase(3, 134, ExpectedResult = new int[] { 134 })]
        [TestCase(4, -134, 4, 56, 4890, 903, 384794, 2212, -42, ExpectedResult = new int[] { -134, 4, 4890, 384794, -42 })]
        [TestCase(0, -4242, -3005, 9233, 78430, 853, -10000, 1244, ExpectedResult = new int[] { -3005, 78430, -10000 })]
        [TestCase(9, 99999, -85875, 956509, 656, -91193449, ExpectedResult = new int[] { 99999, 956509, -91193449 })]
        [TestCase(5, -230, 1298, 9929918, ExpectedResult = new int[0])]
        [TestCase(2, 22, 2, 182, 200, -82, -29, 222222, ExpectedResult = new int[] { 22, 2, 182, 200, -82, -29, 222222 })]
        [TestCase(2, new int[] { -34, -2982, 093, -2, 184, 489027580 }, ExpectedResult = new int[] { -2982, -2, 489027580 })]
        public int[] FilterDigitTest(byte digit, params int[] numbers)
        {
            return FilterDigit(digit, numbers);
        }

        [TestCase(10)]
        public void FilterDigitTestArgumentOutOfRangeException(byte digit, params int[] numbers)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => FilterDigit(digit, numbers));
        }

        [TestCase(3)]
        [TestCase(8, new int[0])]
        public void FilterDigitTestArgumentException(byte digit, params int[] numbers)
        {
            Assert.Throws<ArgumentException>(() => FilterDigit(digit, numbers));
        }
        #endregion

        #region FindNthRoot tests
        [TestCase(1, 5, 0.01, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        [TestCase(999, 2, 1, ExpectedResult = 32)]
        [TestCase(231208092, 200, 0.00001, ExpectedResult = 1.10108)]
        [TestCase(1298, 9, 0.0000001, ExpectedResult = 2.2177848)]
        [TestCase(8329.28109, 2, 0.001, ExpectedResult = 91.265)]
        [TestCase(-239.029, 5, 0.001, ExpectedResult = -2.99)]
        [TestCase(0, 100, 0.000001, ExpectedResult = 0)]
        public double FindNthRootTest(double number, byte power, double precision)
        {
            return FindNthRoot(number, power, precision);
        }

        [TestCase(-32.429, 0, 0.001)]
        [TestCase(2345, 88, 23)]
        [TestCase(2.39, 228, -0.001)]
        [TestCase(124224, 92, 0)]
        public void FindNthRootTestArgumentOutOfRangeException(double number, byte power, double precision)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => FindNthRoot(number, power, precision));
        }

        [TestCase(-28323, 24, 0.001)]
        [TestCase(-0.23891, 4, 0)]
        public void FintNthRootTestArgumentException(double number, byte power, double precision)
        {
            Assert.Throws<ArgumentException>(() => FindNthRoot(number, power, precision));
        }
        #endregion
    }
}
