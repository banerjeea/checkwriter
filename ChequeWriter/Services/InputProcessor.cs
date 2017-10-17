using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChequeWriter.Validator;

namespace ChequeWriter.Services
{
    public interface IInputProcessor
    {
        string ProcessInput(string num);

    }
    public class InputProcessor : IInputProcessor
    {
        private readonly INumberConverter _converter;
        private readonly IInputValidator _inputValidator;
        private const string InvalidInputError = " is an invalid input.";
        private const string DollarText = " DOLLARS AND";
        private const string CentsText = " CENTS.";

        public InputProcessor(INumberConverter converter, IInputValidator validator)
        {
            _converter = converter;
            _inputValidator = validator;
        }

        public string ProcessInput(string num)
        {
            if (!_inputValidator.Validate(num))
            {
                return num + InvalidInputError;
            }

            var word = new StringBuilder();
            var firstNumber = 0;
            var secondNumber = 0;

            if (num.Contains('.'))
            {
                var numbers = num.Split('.');
                if (numbers[1].Length > 2)
                    return num + InvalidInputError;

                firstNumber = Convert.ToInt32(numbers[0]);
                secondNumber = Convert.ToInt32(numbers[1]);

            }
            else
                firstNumber = Convert.ToInt32(num);

            var dollarAmount = _converter.NumberToWords(firstNumber, word) + DollarText;
            var centsAmount = _converter.NumberToWords(secondNumber, word.Clear()) + CentsText;
            return (dollarAmount + centsAmount).Trim();
        }

    }
}
