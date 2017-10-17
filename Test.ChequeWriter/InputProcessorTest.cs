using System;
using ChequeWriter.Services;
using ChequeWriter.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.ChequeWriter
{
    [TestClass]
    public class InputProcessorTest
    {
        private INumberConverter _converter;
        private IInputValidator _inputValidator;
        private IInputProcessor _inputProcessor;

        [TestInitialize]
        public void SetUp()
        {
            _converter = new NumberConverter();
            _inputValidator = new InputValidator();
            _inputProcessor = new InputProcessor(_converter, _inputValidator);
        }

        [TestMethod]
        public void TestInBillionDollarRange()
        {
            var word = _inputProcessor.ProcessInput("1357256.32");
            Assert.AreEqual(word.Trim(), "one million, three hundred and fifty seven thousand, two hundred and fifty six DOLLARS AND thirty two CENTS.");
        }

        [TestMethod]
        public void TestInHundredDollarRange()
        {
            var word = _inputProcessor.ProcessInput("120");
            Assert.AreEqual(word.Trim(), "one hundred and twenty DOLLARS AND zero CENTS.");
        }

        [TestMethod]
        public void TestZeroDollarAsInvalidInput()
        {
            var word = _inputProcessor.ProcessInput("0");
            Assert.AreEqual(word.Trim(), "0 is an invalid input.");
        }

        [TestMethod]
        public void TestTwoBillionDollarAsInvalidInput()
        {
            var word = _inputProcessor.ProcessInput("2000000000");
            Assert.AreEqual(word.Trim(), "2000000000 is an invalid input.");
        }

        [TestMethod]
        public void TestNegativeDollarAmountAsInvalidInput()
        {
            var word = _inputProcessor.ProcessInput("-10");
            Assert.AreEqual(word.Trim(), "-10 is an invalid input.");
        }

        [TestMethod]
        public void TestMoreThanTwoDecimalPointsAsInvalidInput()
        {
            var word = _inputProcessor.ProcessInput("3.310");
            Assert.AreEqual(word.Trim(), "3.310 is an invalid input.");

        }
    }
}
