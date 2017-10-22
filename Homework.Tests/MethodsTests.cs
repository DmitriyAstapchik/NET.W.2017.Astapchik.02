using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Homework.Methods;

namespace Homework.Tests
{
    [TestClass]
    public class MethodsTests
    {
        [TestMethod]
        public void InsertNumber_15_15_0_0_Result15()
        {
            int firstNumber = 15;
            int secondNumber = 15;
            byte start = 0;
            byte end = 0;

            var actual = InsertNumber(firstNumber, secondNumber, start, end);

            Assert.AreEqual(15, actual);
        }

        [TestMethod]
        public void InsertNumber_8_15_0_0_Result9()
        {
            int firstNumber = 8;
            int secondNumber = 15;
            byte start = 0;
            byte end = 0;

            var actual = InsertNumber(firstNumber, secondNumber, start, end);

            Assert.AreEqual(9, actual);
        }

        [TestMethod]
        public void InsertNumber_8_15_3_8_Result120()
        {
            int firstNumber = 8;
            int secondNumber = 15;
            byte start = 3;
            byte end = 8;

            var actual = InsertNumber(firstNumber, secondNumber, start, end);

            Assert.AreEqual(120, actual);
        }

        [TestMethod]
        public void InsertNumber_4444_1_31_31_ResultLessThanZero()
        {
            int firstNumber = 4444;
            int secondNumber = 1;
            byte start = 31;
            byte end = 31;

            var actual = InsertNumber(firstNumber,  secondNumber, start, end);

            Assert.IsTrue(actual < 0);
        }

        [TestMethod]
        public void InsertNumber_999999999_0_0_31_Result0()
        {
            int firstNumber = 999999999;
            int secondNumber = 0;
            byte start = 0;
            byte end = 31;

            var actual = InsertNumber(firstNumber, secondNumber, start, end);

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_123_456_3_33_ArgumentOutOfRangeException()
        {
            int firstNumber = 123;
            int secondNumber = 456;
            byte start = 3;
            byte end = 33;

            InsertNumber(firstNumber, secondNumber, start, end);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_200_400_40_20_ArgumentOutOfRangeException()
        {
            int firstNumber = 200;
            int secondNumber = 400;
            byte start = 40;
            byte end = 20;

            InsertNumber(firstNumber,  secondNumber, start, end);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_22_2_22_2_ArgumentException()
        {
            int firstNumber = 22;
            int secondNumber = 2;
            byte start = 22;
            byte end = 2;

            InsertNumber(firstNumber,  secondNumber, start, end);
        }
    }
}
