﻿using NUnit.Framework;
using InventoryManager.InputValidation;

namespace InventoryManagerTests
{    
    [TestFixture]
    public class DataValidationTests
    {
        DataValidation dataValidation = new DataValidation();

        [TestCase("abcd", false)]
        [TestCase("ab123", false)]
        [TestCase("", false)]
        [TestCase("     ", false)]
        [TestCase("@%^", false)]
        [TestCase("123", true)]
        [TestCase("2345678", true)]
        [TestCase(" 0 ", true)]
        [Test]
        public void IsInputInt_ShallReturnTrue_IfInputIsInt(string inputData, bool isInputInt)
        {
            bool result = dataValidation.IsDataInt(inputData);
            Assert.AreEqual(isInputInt, result);
        }


        [TestCase("21.67", true)]
        [TestCase("123", true)]
        [TestCase(" 0.0000 ", true)]
        [TestCase("ab123", false)]
        [TestCase("", false)]
        [TestCase("     ", false)]
        [TestCase("@%^", false)]
        [Test]
        public void IsInputDecimal_ShallReturnTrue_IfInputIsDecimal(string inputData, bool isInputDecimal)
        {
            bool result = dataValidation.IsInputDecimal(inputData);
            Assert.AreEqual(isInputDecimal, result);
        }

        [TestCase("5435", false)]
        [TestCase(null, true)]
        [TestCase("hello", false)]
        [TestCase("", true)]
        [TestCase("Welcome123", false)]
        [Test]
        public void IsDataEmpty_ShallReturnTrue_IfInputIsNullOrEmpty(string inputData, bool isDataEmpty)
        {
            bool result = dataValidation.IsDataEmpty(inputData);
            Assert.AreEqual(result, isDataEmpty);
        }
    }
}
