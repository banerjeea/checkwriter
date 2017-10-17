using System;
using ChequeWriter.Services;
using ChequeWriter.Validator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.ChequeWriter
{
    [TestClass]
    public class InputValidatorTest
    {
        private IInputValidator _inputValidator;

        [TestInitialize]
        public void SetUp()
        {
            _inputValidator = new InputValidator();
        }


        [TestMethod]
        public void TestForDecimalNumberToBeTrue()
        {
            var num = _inputValidator.Validate("123.33");
            Assert.IsTrue(num);
        }

        [TestMethod]
        public void TestForStringInputToBeFalse()
        {
            var num = _inputValidator.Validate("test");
            Assert.IsFalse(num);
        }

        [TestMethod]
        public void TestZeroInputAsFalse()
        {
            var num = _inputValidator.Validate("0");
            Assert.IsFalse(num);
        }
    }
}
