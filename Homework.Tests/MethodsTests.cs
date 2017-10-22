using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Homework.Methods;

namespace Homework.Tests
{
    [TestClass]
    public class MethodsTests
    {
        [TestMethod]
        public void InsertNumber_22_44_2_4_Result52()
        {
            int firstNumber = 22;
            int secondNumber = 44;
            byte i = 2;
            byte j = 4;

            InsertNumber(firstNumber, ref secondNumber, i, j);

            Assert.AreEqual(52, secondNumber);
        }

        [TestMethod]
        public void InsertNumber_99_9999_0_31_Result99()
        {
            int firstNumber = 99;
            int secondNumber = 9999;
            byte i = 0;
            byte j = 31;

            InsertNumber(firstNumber, ref secondNumber, i, j);

            Assert.AreEqual(99, secondNumber);
        }

        [TestMethod]
        public void InsertNumber_Minus55555_55555_30_31_ResultLessThanZero()
        {
            int firstNumber = -55555;
            int secondNumber = 55555;
            byte i = 30;
            byte j = 31;

            InsertNumber(firstNumber, ref secondNumber, i, j);

            Assert.IsTrue(secondNumber < 0);
        }

        [TestMethod]
        public void InsertNumber_4444_Minus4444_0_30_ResultNotEqualsMinus4444()
        {
            int firstNumber = 4444;
            int secondNumber = -4444;
            byte i = 0;
            byte j = 30;

            InsertNumber(firstNumber, ref secondNumber, i, j);

            Assert.AreNotEqual(-4444, secondNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_123_456_3_33_ArgumentOutOfRangeException()
        {
            int firstNumber = 123;
            int secondNumber = 456;
            byte i = 3;
            byte j = 33;

            InsertNumber(firstNumber, ref secondNumber, i, j);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_200_400_40_20_ArgumentOutOfRangeException()
        {
            int firstNumber = 200;
            int secondNumber = 400;
            byte i = 40;
            byte j = 20;

            InsertNumber(firstNumber, ref secondNumber, i, j);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_22_2_22_2_ArgumentException()
        {
            int firstNumber = 22;
            int secondNumber = 2;
            byte i = 22;
            byte j = 2;

            InsertNumber(firstNumber, ref secondNumber, i, j);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_868_886688_15_15_ArgumentException()
        {
            int firstNumber = 868;
            int secondNumber = 886688;
            byte i = 15;
            byte j = 15;

            InsertNumber(firstNumber, ref secondNumber, i, j);
        }
    }
}
