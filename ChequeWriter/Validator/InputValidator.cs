using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeWriter.Validator
{
    public interface IInputValidator
    {
        bool Validate(string input);
    }

    /// <summary>
    /// Validates if input can be converted to decimals, also if in
    /// given range.
    /// </summary>
    public class InputValidator : IInputValidator
    {

        public bool Validate(string input)
        {
            decimal output;
            var isTrue = decimal.TryParse(input, out output);
            return (isTrue && output > 0 && output < 2000000000);

        }
    }

}
